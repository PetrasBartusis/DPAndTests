

using GameServer.Models;
/**
* @(#) IEnemyCreator.cs
*/
namespace GameServer.EnemyBuilder
{
	public interface IEnemyCreator
	{
        EnemyParty GetEnemyParty(Coordinates position, LevelType type);
        EnemyParty GetEnemyParty(int dificultyLevel, Coordinates position, LevelType type);
        EnemyParty GetEnemyParty(int dificultyLevel, int partySize, Coordinates position, LevelType type);

    }
	
}
