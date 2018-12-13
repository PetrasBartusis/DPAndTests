/**
 * @(#) AddMoney.cs
 */

using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace GameClient.CompositeAndInterpreter
{
	public class AddMoney : CheatComponent
	{
	    private CheatComponent p;
	    private int val;

	    public int[] getStats()
	    {
	        int[] values = p.getStats();
	        values[3] = values[3] + val;
	        return values;
	    }

	    public AddMoney(CheatComponent stats, int val)
	    {
	        p = stats;
	        this.val = val;
	    }
	}
	
}
