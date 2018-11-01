using GameServer.EnemyBuilder;
using GameServer.Models;

namespace GameServer.EnemyBuilder
{
    public class EnemyPartyBuilder : IEnemyPartyBuilder
    {

        //EnemyPartyBuilder(EnemyFactory factory) => this.factory = factory;

        //private EnemyFactory factory;

        private EnemyParty enemyParty;

        IEnemyPartyBuilder startNew(int id, Position p)
        {
            enemyParty = new EnemyParty(id, p);
            return this;
        }

        EnemyParty build() => enemyParty;

        IEnemyPartyBuilder addEnemy(EnemyType type, int difficultyLevel)
        {
            //switch (type)
            //{
            //    case EnemyType.goblin:
            //        enemyParty.addEnemy(factory.createGoblin(difficultyLevel));
            //        break;

            //    case EnemyType.spider:
            //        enemyParty.addEnemy(factory.createSpider(difficultyLevel));
            //        break;

            //    case EnemyType.elemental:
            //        enemyParty.addEnemy(factory.createElemental(difficultyLevel));
            //        break;

            //    case EnemyType.dragon:
            //        enemyParty.addEnemy(factory.createDragon(difficultyLevel));
            //        break;

            //    case EnemyType.slime:
            //        enemyParty.addEnemy(factory.createSlime(difficultyLevel));
            //        break;

            //    case EnemyType.skeleton:
            //        enemyParty.addEnemy(factory.createSkeleton(difficultyLevel));
            //        break;

            //    case EnemyType.demon:
            //        enemyParty.addEnemy(factory.createDemon(difficultyLevel));
            //        break;
            //}

            return this;
        }

        IEnemyPartyBuilder IEnemyPartyBuilder.startNew(int id, Position p)
        {
            throw new System.NotImplementedException();
        }

        EnemyParty IEnemyPartyBuilder.build()
        {
            throw new System.NotImplementedException();
        }

        IEnemyPartyBuilder IEnemyPartyBuilder.addEnemy(EnemyType type, int difficultyLevel)
        {
            throw new System.NotImplementedException();
        }
    }
}
