using GameServer.Models;

namespace GameServer.EnemyBuilder
{
    public class EnemyPartyBuilder : IEnemyPartyBuilder
    {
        private static string Tag = "EnemyPartyBuilder";

        private EnemyFactory.EnemyFactory factory;

        void IEnemyPartyBuilder.setFactory(EnemyFactory.EnemyFactory factory)
        {
            this.factory = factory;
        }

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
                    LoggerLazy.getInstance().log(Tag, "createWeakEnemy");
                    enemyParty.addEnemy(factory.createWeakEnemy());
                    break;

                case 1:
                    LoggerLazy.getInstance().log(Tag, "createAvarageEnemy");
                    enemyParty.addEnemy(factory.createAvarageEnemy());
                    break;

                case 2:
                    LoggerLazy.getInstance().log(Tag, "createStrongEnemy");
                    enemyParty.addEnemy(factory.createStrongEnemy());
                    break;
                default:
                    LoggerLazy.getInstance().log(Tag, "create default Enemy");
                    enemyParty.addEnemy(factory.createWeakEnemy());
                    break;
            }

            return this;
        }

        EnemyParty IEnemyPartyBuilder.Build() => enemyParty;
    }
}
