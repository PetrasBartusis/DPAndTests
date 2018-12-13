using System;
using GameServer.Strategy;

namespace GameServer.Visitor
{
    public class Plentiful : EffectStrength
    {
        int multiplier = 2;
        public Plentiful(){

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
