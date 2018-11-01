
using System.Collections.Generic;
using GameServer.Models;
using GameServer.Strategy;

namespace GameServer.EnemyBuilder
{
    public class EnemyParty
    {
        public List<Entity> enemies;

        public Coordinates position;

        public EnemyParty(Coordinates p)
        {
            this.position = p;
            enemies = new List<Entity>();
        }
        public EnemyParty(List<Entity> entities, Coordinates p)
        {
            this.position = p;
            enemies = entities;
        }

        public void addEnemy(Entity enemy)
        {
            enemies.Add(enemy);
        }
    }
}


