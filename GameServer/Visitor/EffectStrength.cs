using System;
using GameServer.Strategy;

namespace GameServer.Visitor
{
    public interface EffectStrength
    {
        int calculateStrength(DamageEffect effect);
        int calculateStrength(HealthEffect effect);
        int calculateStrength(BuffEffect effect);
    }
}
