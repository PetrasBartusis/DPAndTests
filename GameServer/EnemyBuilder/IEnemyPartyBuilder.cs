using GameServer.EnemyFactory;
using GameServer.Models;

namespace GameServer.EnemyBuilder
{
    public interface IEnemyPartyBuilder
    {
        IEnemyPartyBuilder startNew(int id, Position p);

        EnemyParty build();

        IEnemyPartyBuilder addEnemy(EnemyType type, int difficultyLevel);

    }
}

