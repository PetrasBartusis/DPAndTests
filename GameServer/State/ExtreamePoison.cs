using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.State
{
    public class ExtreamePoison : IState
    {
        int i = 1;
        public void Handle(Entity entity)
        {
            entity.CurrentHitpoints -= ((entity.Hitpoints / 10) * i++) + 1;
        }

        public StateType StateType()
        {
            return State.StateType.POISON;
        }
    }
}
