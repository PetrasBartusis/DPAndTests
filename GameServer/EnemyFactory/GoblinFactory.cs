/**
 * @(#) GoblinFactory.cs
 */

using System;

namespace GameServer.EnemyFactory
{
    public class GoblinFactory
    {
        public Entity createGoblin(int difficultyLevel)
        {
            Entity enemy;
            const int ATT = 2;
            const int DEF = 4;

            Random rand = new Random();
            int type = rand.Next(0, 1);
            switch (type)
            {
                default:
                case 0: enemy = new Enemies.GoblinRogue("Goblin Rogue", 10, ATT, DEF); break;
                case 1: enemy = new Enemies.GoblinWarrior("Goblin Warrior", 20, ATT, DEF); break;
            }
            return enemy;
        }
    }

}
