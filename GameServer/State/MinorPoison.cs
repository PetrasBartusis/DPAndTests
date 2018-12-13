using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.State
{
    public class MinorPoison : IState
    {
        public void Handle(Entity entity)
        {
            entity.CurrentHitpoints -= 1;
        }
    }
}
