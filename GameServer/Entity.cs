

using GameServer.Models;
/**
* @(#) Entity.cs
*/
namespace GameServer
{
	public class Entity
	{
        public string name;
		public int hitpoints;
        public int currentHitpoints;
        public int attack;
        public int defence;
		
		public Entity( string n, int hp, int a, int d )
        {
            name = n;
            hitpoints = hp;
            attack = a;
            defence = d;
            currentHitpoints = hp;
		}

        public override string ToString()
        {
            return string.Format(" Name = {0}, HP = {1}, ATTACK = {2}, DEFENCE = {3} ",name, currentHitpoints, attack, defence);
        }
    }
	
}
