/**
 * @(#) Entity.cs
 */

namespace GameServer
{
	public class Entity
	{
        public string name;
		public int hitpoints;
        public int attack;
        public int defence;
		
		public Entity( string n, int hp, int a, int d )
		{
            name = n;
            hitpoints = hp;
            attack = a;
            defence = d;
		}
		
	}
	
}
