/**
 * @(#) AddAttack.cs
 */

namespace GameClient.CompositeAndInterpreter
{
	public class AddAttack : CheatComponent
	{
	    private CheatComponent p;
	    private int val;

	    public int[] getStats()
	    {
	        int[] values = p.getStats();
	        values[1] = values[1] + val;
	        return values;
	    }

	    public AddAttack(CheatComponent stats, int val)
	    {
	        p = stats;
	        this.val = val;
	    }
    }
	
}
