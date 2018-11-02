
using System;
using System.Collections.Generic;
using System.Text;
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

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(string.Format("{2}***Enemy Party in position [{0}, {1}]***{2}", position.x, position.y, Environment.NewLine));
            foreach(Entity e in enemies)
            {
                builder.Append("+++").Append(e.ToString()).Append(Environment.NewLine);
            }
            builder.Append("***   ***").Append(Environment.NewLine);
            return builder.ToString();
        }
    }
}


