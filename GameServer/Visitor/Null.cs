using System;
using GameServer.Strategy;

namespace GameServer.Visitor
{
    public class Null: EffectStrength
    {
        int multiplier = 0;
        public Null()
        {
        }

        public int calculateStrength(DamageEffect effect)
        {
            return 0;
        }

        public int calculateStrength(HealthEffect effect)
        {
            return 0;
        }

        public int calculateStrength(BuffEffect effect)
        {
            return 0;
        }
    }
}
