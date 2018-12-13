using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.State
{
    public interface IState
    {
        void Handle(Entity entity);
    }
}
