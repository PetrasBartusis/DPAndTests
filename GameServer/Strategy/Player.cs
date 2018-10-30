
using System;
using System.Collections;
using System.Collections.Generic;
/**
* @(#) Player.cs
*/
namespace GameServer.Strategy
{
	public class Player : Entity
	{
		int level;
		
		int experience;
		
		int gold;
		
		LinkedList<Item> items;

        int count;

        public Player(string n, int hp, int a, int d, int level, int experience, int gold) : base(n, hp, a, d)
        {
            this.level = level;
            this.experience = experience;
            this.gold = gold;
            this.items = new LinkedList<Item>();
            count = 0;
        }

        public void addItem(Item item)
        {
            items.AddLast(item);
            count++;
        }

        internal void damagePlayer(int damage)
        {
            setHp(this.currentHitpoints - damage);
        }

        public void useItem(string name)
        {
            Item[] arr = new Item[count];
            items.CopyTo(arr, 0);
            foreach (Item item in arr)
            {
                if (name.Equals(item.getName()))
                {
                    item.useEffect(this);
                    items.Remove(item);
                    break;
                }
            }
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
