using GameServer.Models;

namespace GameServer.EnemyBuilder
{
    public class EnemyPartyBuilder : IEnemyPartyBuilder
    {

        public EnemyPartyBuilder(EnemyFactory.EnemyFactory factory) => this.factory = factory;

        private EnemyFactory.EnemyFactory factory;

        private EnemyParty enemyParty;

        IEnemyPartyBuilder IEnemyPartyBuilder.StartNew(Coordinates p)
        {
            enemyParty = new EnemyParty(p);
            return this;
        }
        public IEnemyPartyBuilder AddEnemy(int difficultyLevel)
        {
            switch (difficultyLevel % 3)
            {
                case 0:
                    enemyParty.addEnemy(factory.createWeakEnemy());
                    break;

                case 1:
                    enemyParty.addEnemy(factory.createWeakEnemy());
                    break;

                case 2:
                    enemyParty.addEnemy(factory.createWeakEnemy());
                    break;
                default:
                    enemyParty.addEnemy(factory.createWeakEnemy());
                    break;
            }

            return this;
        }

        EnemyParty IEnemyPartyBuilder.Build() => enemyParty;
    }
}
