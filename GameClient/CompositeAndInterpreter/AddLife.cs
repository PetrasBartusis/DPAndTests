/**
 * @(#) AddLife.cs
 */

namespace GameClient.CompositeAndInterpreter
{
	public class AddLife : CheatComponent
	{
	    private CheatComponent p;
	    private int val;

	    public int[] getStats()
	    {
	        int[] values = p.getStats();
	        values[0] = values[0] + val;
	        return values;
	    }

	    public AddLife(CheatComponent stats, int val)
	    {
	        p = stats;
	        this.val = val;
	    }
    }
	
}
