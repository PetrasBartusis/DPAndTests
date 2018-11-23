/**
 * @(#) GoblinFactory.cs
 */

using System;

namespace GameServer.EnemyFactory
{
    public class GoblinFactory
    {
        public static Entity createGoblin(GoblinTypes type, int difficultyLevel)
        {
            Entity enemy;
            const int ATT = 2;
            const int DEF = 4;

            switch (type)
            {
                default:
                case GoblinTypes.rogue: enemy = new Enemies.GoblinRogue("Goblin Rogue", 10, difficultyLevel * ATT, difficultyLevel * DEF); break;
                case GoblinTypes.warrior: enemy = new Enemies.GoblinWarrior("Goblin Warrior", 20, difficultyLevel * ATT, difficultyLevel * DEF); break;
            }
            return enemy;
        }
    }

}
