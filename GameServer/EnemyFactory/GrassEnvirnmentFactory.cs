using GameServer.EnemyFactory.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.EnemyFactory
{
    public class GrassEnvirnmentFactory : EnemyFactory
    {
        public GrassEnvirnmentFactory()
        {
        }

        public override Entity createAvarageEnemy()
        {
            return new GoblinWarrior("Goblin Warrior", 20, 10, 3);
        }

        public override Entity createStrongEnemy()
        {
            return new EarthElemental("Earth Elemental", 100, 15, 30);
        }

        public override Entity createWeakEnemy()
        {
            return new Spider("Spider", 10, 1, 0);
        }
    }
}
