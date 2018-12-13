/**
 * @(#) AddDefence.cs
 */

namespace GameClient.CompositeAndInterpreter
{
	public class AddDefence : CheatComponent
	{
	    private CheatComponent p;
	    private int val;

	    public int[] getStats()
	    {
	        int[] values = p.getStats();
	        values[2] = values[2] + val;
	        return values;
	    }

	    public AddDefence(CheatComponent stats, int val)
	    {
	        p = stats;
	        this.val = val;
	    }
    }
	
}
