/**
 * @(#) AddDefence.cs
 */

namespace GameClient.CompositeAndInterpreter
{
    public class AddDefence : CheatComponent
    {
        private CheatComponent exp1;
        private CheatComponent exp2;

        public int[] getStats()
        {
            int[] values = exp1.getStats();
            int[] add = exp2.getStats();

            values[2] = values[2] + add[2];
            return values;
        }

        public AddDefence(CheatComponent stats, CheatComponent val)
        {
            exp1 = stats;
            this.exp2 = val;
        }

    }
}
