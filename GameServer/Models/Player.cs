
using System;
using System.Collections;
using System.Collections.Generic;
/**
* @(#) Player.cs
*/
namespace GameServer.Models
{
	public class Player : Entity
	{
		public int level { get; set; }

        public int experience { get; set; }

        public int gold { get; set; }
        private List<Item> items;

        int itemCount;

        public Player(int id, int x, int y, string name, int hitpoints, int attack, int defence, int level, int experience, int gold) : base(id, x, y, name, hitpoints, attack, defence)
        {
            this.level = level;
            this.experience = experience;
            this.gold = gold;
            this.items = new List<Item>();
            itemCount = 0;
        }

        public void addItem(Item item)
        {
            items.Add(item);
            itemCount++;
        }

        public void damagePlayer(int damage)
        {
            setHp(this.currentHitpoints - damage);
        }

        public void useItem(string name)
        {
            Item[] arr = new Item[itemCount];
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
            hitpoints = hp;
            attack = a;
            defence = d;
            level = lv;
            experience = xp;
            gold = g;
        }

        public override string ToString()
        {
            return string.Format("Player hp  = {0}, Player attack  = {1}, Player defence  = {2},", currentHitpoints, attack, defence);
        }

        public void setHp(int hitpoints) => this.currentHitpoints = hitpoints;
        public int getHp() => this.currentHitpoints;

        public int getMaxHp() => this.hitpoints;

        public int setDefence(int defence) => this.defence = defence;
        public int getDefence() => this.defence;

        public int setAttack(int attack) => this.attack = attack;
        public int getAttack() => this.attack;

    }

}
