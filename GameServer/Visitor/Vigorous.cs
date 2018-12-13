using System;
using GameServer.Strategy;

namespace GameServer.Visitor
{
    public class Vigorous : EffectStrength
    {
        int multiplier = 3;
        public Vigorous() {

        }

        public int calculateStrength(DamageEffect effect)
        {
            return multiplier * 3;
        }

        public int calculateStrength(HealthEffect effect)
        {
            return multiplier * 2;
        }

        public int calculateStrength(BuffEffect effect)
        {
            return multiplier;
        }
    }
}
