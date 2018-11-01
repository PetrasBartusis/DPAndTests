/**
 * @(#) Entity.cs
 */

namespace GameServer
{
	public class Entity
	{
		int id;
		string name;
		int hitpoints;
		int attack;
		int defence;
		
		public Entity( string n, int hp, int a, int d )
		{
            name = n;
            hitpoints = hp;
            attack = a;
            defence = d;
		}
		
	}
	
}
