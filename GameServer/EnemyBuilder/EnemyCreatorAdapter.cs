

using System.Collections.Generic;
using GameServer.EnemyFactory;
using GameServer.Models;
/**
* @(#) EnemyCreatorAdapter.cs
*/
namespace GameServer.EnemyBuilder
{
    public class EnemyCreatorAdapter : IEnemyCreator
    {
        private EnemyPartyDirector enemyPartyDirector;

        private void setFactory(LevelType type)
        {
            switch (type)
            {
                case LevelType.FIRE:
                    enemyPartyDirector.setFactory(new FireEnvironmentFactory());
                    break;
                case LevelType.WATER:
                    enemyPartyDirector.setFactory(new WaterEnvironmentFactory());
                    break;
                case LevelType.GRASS:
                    enemyPartyDirector.setFactory(new GrassEnvironmentFactory());
                    break;
                case LevelType.FOREST:
                    enemyPartyDirector.setFactory(new ForestEnvironmentFactory());
                    break;
                case LevelType.GREVEYARD:
                    enemyPartyDirector.setFactory(new GraveyardEnvironmentFactory());
                    break;
            }
        }
        public EnemyCreatorAdapter(EnemyPartyDirector enemyPartyDirector, LevelType type)
        {
            this.enemyPartyDirector = enemyPartyDirector;
        }

        public EnemyParty GetEnemyParty(Coordinates position, LevelType type)
        {
            setFactory(type);
            return enemyPartyDirector.construct(5, 3, position);
        }
        public EnemyParty GetEnemyParty(int dificultyLevel, Coordinates position, LevelType type)
        {
            setFactory(type);
            return enemyPartyDirector.construct(dificultyLevel, 3, position);
        }
        public EnemyParty GetEnemyParty(int dificultyLevel, int partySize, Coordinates position, LevelType type)
        {
            setFactory(type);
            return enemyPartyDirector.construct(dificultyLevel, 3, position);
        }
    }

}