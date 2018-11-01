

using GameServer.Models;
/**
* @(#) IEnemyCreator.cs
*/
namespace GameServer.EnemyBuilder
{
	public interface IEnemyCreator
	{
        EnemyParty GetEnemyParty(int id, Position position);
        EnemyParty GetEnemyParty(int id, int dificultyLevel, Position position);
        EnemyParty GetEnemyParty(int id, int dificultyLevel, int partySize, Position position);

    }
	
}
