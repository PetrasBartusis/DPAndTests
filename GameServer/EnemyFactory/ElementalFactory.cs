/**
 * @(#) ElementalFactory.cs
 */

using System;

namespace GameServer.EnemyFactory
{
	public class ElementalFactory
	{
        public static Entity createElemental(ElementalTypes type, int difficultyLevel)
        {
            Entity enemy;
            const int ATT = 2;
            const int DEF = 4;

            switch (type)
            {
                default:
                case ElementalTypes.air:
                    enemy = new Enemies.AirElemental("air", 10, ATT, DEF); break;
                case ElementalTypes.earth:
                    enemy = new Enemies.EarthElemental("earth", 10, ATT, DEF); break;
                case ElementalTypes.fire:
                    enemy = new Enemies.FireElemental("fire", 10, ATT, DEF); break;
                case ElementalTypes.water:
                    enemy = new Enemies.WaterElemental("water", 10, ATT, DEF); break;
            }
            return enemy;
        }
    }
	
}
