

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

        public EnemyCreatorAdapter(EnemyPartyDirector enemyPartyDirector)
        {
            this.enemyPartyDirector = enemyPartyDirector;
        }

        public EnemyParty GetEnemyParty(Coordinates position)
        {
            return enemyPartyDirector.construct(5, 3, position);
        }
        public EnemyParty GetEnemyParty(int dificultyLevel, Coordinates position)
        {
            return enemyPartyDirector.construct(dificultyLevel, 3, position);
        }
        public EnemyParty GetEnemyParty(int dificultyLevel, int partySize, Coordinates position)
        {
            return enemyPartyDirector.construct(dificultyLevel, 3, position);
        }
    }
	
}
