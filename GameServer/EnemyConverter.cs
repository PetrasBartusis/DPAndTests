using GameServer.EnemyBuilder;
using GameServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer
{
    public static class EnemyConverter
    {

        public static EnemyPartyJson createEnemyPartyJson(EnemyParty enemyParty)
        {
            return new EnemyPartyJson
            {
                x = 0,
                y = 0,
                enemies = createEnemyJsonList(enemyParty.enemies)
            };
        }

        public static List<EnemyJson> createEnemyJsonList(List<Entity> entities)
        {
            List<EnemyJson> enemies = new List<EnemyJson>();
            foreach (Entity e in entities)
            {
                enemies.Add(createEnemyJson(e));
            }
            return enemies;
        }

        public static EnemyJson createEnemyJson(Entity e)
        {
            return new EnemyJson
            {
                name = e.name,
                hitpoints = e.Hitpoints,
                currentHitpoints = e.Hitpoints,
                attack = e.Attack,
                defence = e.Defence
            };
        }

        public static List<EnemyParty> createEnemyParties(ICollection<EnemyPartyJson> partyJsons)
        {
            List<EnemyParty> parties = new List<EnemyParty>();
            foreach (EnemyPartyJson pj in partyJsons)
            {
                parties.Add(createEnemyParty(pj));
            }
            return parties;
        }

        public static EnemyParty createEnemyParty(EnemyPartyJson enemyPartyJson)
        {
            return new EnemyParty(createEnemies(enemyPartyJson.enemies), new Coordinates(enemyPartyJson.x, enemyPartyJson.y));
        }

        public static List<Entity> createEnemies(ICollection<EnemyJson> enemyJsons)
        {
            List<Entity> enemies = new List<Entity>();
            foreach (EnemyJson e in enemyJsons)
            {
                enemies.Add(createEnemy(e));
            }
            return enemies;
        }

        public static Entity createEnemy(EnemyJson enemy)
        {
            return new Entity(enemy.name, enemy.hitpoints, enemy.attack, enemy.defence);
        }
    }
}
