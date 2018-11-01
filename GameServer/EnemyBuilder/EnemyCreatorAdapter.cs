

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

        public EnemyParty GetEnemyParty(int id, Position position)
        {
            return enemyPartyDirector.construct(5, 3, position, id);
        }
        public EnemyParty GetEnemyParty(int id, int dificultyLevel, Position position)
        {
            return enemyPartyDirector.construct(dificultyLevel, 3, position, id);
        }
        public EnemyParty GetEnemyParty(int id, int dificultyLevel, int partySize, Position position)
        {
            return enemyPartyDirector.construct(dificultyLevel, 3, position, id);
        }
    }
	
}
