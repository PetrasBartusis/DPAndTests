/**
 * @(#) Entity.cs
 */

namespace GameServer.Models
{
    public class Entity
    {
        public int id { get; protected set; }

        public string name { get; protected set; }

        public int hitpoints { get; protected set; }

        public int currentHitpoints { get; protected set; }

        public int attack { get; protected set; }

        public int defence { get; protected set; }

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
