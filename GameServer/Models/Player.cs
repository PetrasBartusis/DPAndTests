
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
/**
* @(#) Player.cs
*/
namespace GameServer.Models
{
	public class Player : Entity, ICloneable
	{
		public int level { get; set; }

        public int experience { get; set; }

        public int gold { get; set; }
        private List<Item> items;

        public int x;
        public int y;
        public int id;

        public KillCounter kc;

        int itemCount;

        public Player(int id, int x, int y, string name, int hitpoints, int attack, int defence, int level, int experience, int gold) : base(name, hitpoints, attack, defence)
        {
            this.level = level;
            this.experience = experience;
            this.gold = gold;
            this.items = new List<Item>();
            itemCount = 0;
            this.x = x;
            this.y = y;
            kc = new KillCounter();
        }

        public void addKill()
        {
            kc.Increment();
        }

        public void addItem(Item item)
        {
            items.Add(item);
            itemCount++;
        }
        public IReadOnlyCollection<Item> getItems()
        {
            return items.AsReadOnly();
        }

        public void damagePlayer(int damage)
        {
            setHp(this.CurrentHitpoints - damage);
        }

        public void useItem(string name)
        {
            Item[] arr = new Item[items.Count];
            items.CopyTo(arr, 0);
            foreach (Item item in arr)
            {
                if (name.Equals(item.name))
                {
                    item.useEffect(this);
                    items.Remove(item);
                    break;
                }
            }
        }

        public void update(string n, int hp, int a, int d, int lv, int xp, int g)
        {
            name = n;
            Hitpoints = hp;
            Attack = a;
            Defence = d;
            level = lv;
            experience = xp;
            gold = g;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            output.Append("\n");
            foreach(Item i in items)
            {
                output.Append(i.ToString()).Append("\n");
            }
            return output.Append("KillCount: ").Append(kc.killCount).ToString();
        }

        public void setHp(int hitpoints) => this.CurrentHitpoints = hitpoints;
        public int getHp() => this.CurrentHitpoints;

        public int getMaxHp() => this.Hitpoints;

        public int setDefence(int defence) => this.Defence = defence;
        public int getDefence() => this.Defence;

        public int setAttack(int attack) => this.Attack = attack;
        public int getAttack() => this.Attack;

        public object Clone()
        {
            Player p = (Player)this.MemberwiseClone();
            p.kc = new KillCounter();
            p.items = new List<Item>();
            return p;
        }
        public object DeepClone()
        {
            Player p = (Player) this.MemberwiseClone();
            p.kc = (KillCounter)kc.Clone();
            p.items = new List<Item>();
            foreach (var item in items)
            {
                p.items.Add((Item)item.Clone());
            }

            return p;
        }
    }

}
