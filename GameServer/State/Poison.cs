using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.State
{
    public class Poison : IState
    {
        public void Handle(Entity entity)
        {
            entity.CurrentHitpoints -= (entity.Hitpoints / 10) + 1;
        }

        public StateType StateType()
        {
            return State.StateType.POISON;
        }
    }
}
