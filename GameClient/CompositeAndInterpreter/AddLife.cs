/**
 * @(#) AddLife.cs
 */

namespace GameClient.CompositeAndInterpreter
{
	public class AddLife : CheatComponent
	{
        private CheatComponent exp1;
        private CheatComponent exp2;

        public int[] getStats()
        {
            int[] values = exp1.getStats();
            int[] add = exp2.getStats();

            values[0] = values[0] + add[0];
            return values;
        }

        public AddLife(CheatComponent stats, CheatComponent val)
        {
            exp1 = stats;
            this.exp2 = val;
        }
    }
	
}
