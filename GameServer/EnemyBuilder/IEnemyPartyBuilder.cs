using GameServer.EnemyFactory;
using GameServer.Models;

namespace GameServer.EnemyBuilder
{
    public interface IEnemyPartyBuilder
    {
        IEnemyPartyBuilder StartNew(int id, Position p);
        IEnemyPartyBuilder AddEnemy(int difficultyLevel);

        EnemyParty Build();


    }
}

