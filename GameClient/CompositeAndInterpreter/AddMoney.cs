/**
 * @(#) AddMoney.cs
 */

using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace GameClient.CompositeAndInterpreter
{
	public class AddMoney : CheatComponent
	{
        private CheatComponent exp1;
        private CheatComponent exp2;

        public int[] getStats()
        {
            int[] values = exp1.getStats();
            int[] add = exp2.getStats();

            values[3] = values[3] + add[3];
            return values;
        }

        public AddMoney(CheatComponent stats, CheatComponent val)
        {
            exp1 = stats;
            this.exp2 = val;
        }
    }
	
}
