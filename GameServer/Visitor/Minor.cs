using System;
using GameServer.Strategy;

namespace GameServer.Visitor
{
    public class Minor: EffectStrength
    {
        int multiplier = 1;
        public Minor(){

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
