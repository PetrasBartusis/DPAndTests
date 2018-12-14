using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.State
{
    public class Fear : IState
    {
        public void Handle(Entity entity)
        {
            throw new NotImplementedException();
        }

        public StateType StateType()
        {
            return State.StateType.FEAR;
        }
    }
}
