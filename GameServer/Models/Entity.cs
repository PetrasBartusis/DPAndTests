/**
 * @(#) Entity.cs
 */

namespace GameServer.Models
{
	public class Entity
	{
		protected int id;

        protected string name;

        protected int hitpoints;

        protected int currentHitpoints;

        protected int attack;

        protected int defence;
		
		public Entity( string n, int hp, int a, int d )
		{
            name = n;
            hitpoints = hp;
            attack = a;
            defence = d;
            currentHitpoints = hitpoints;
		}
		
	}
	
}
