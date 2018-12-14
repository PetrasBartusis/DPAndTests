/**
 * @(#) AddAttack.cs
 */

namespace GameClient.CompositeAndInterpreter
{
	public class AddAttack : CheatComponent
	{
	    private CheatComponent exp1;
	    private CheatComponent exp2;

	    public int[] getStats()
	    {
	        int[] values = exp1.getStats();
            int[] add = exp2.getStats();

            values[1] = values[1] + add[1]; ;
	        return values;
	    }

	    public AddAttack(CheatComponent stats, CheatComponent val)
	    {
	        exp1 = stats;
	        this.exp2 = val;
	    }
    }
	
}
