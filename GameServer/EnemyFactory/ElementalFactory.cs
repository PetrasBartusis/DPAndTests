/**
 * @(#) ElementalFactory.cs
 */

using System;

namespace GameServer.EnemyFactory
{
	public class ElementalFactory
	{
        public Entity createElemental(int difficultyLevel)
        {
            Entity enemy;
            const int ATT = 2;
            const int DEF = 4;

            Random rand = new Random();
            int type = rand.Next(0, 3);
            switch (type)
            {
                default:
                case 0: enemy = new Enemies.AirElemental("air", 10, ATT, DEF); break;
                case 1: enemy = new Enemies.EarthElemental("earth", 10, ATT, DEF); break;
                case 2: enemy = new Enemies.FireElemental("fire", 10, ATT, DEF); break;
                case 3: enemy = new Enemies.WaterElemental("water", 10, ATT, DEF); break;
            }
            return enemy;
        }
    }
	
}
