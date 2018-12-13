/**
 * @(#) CheatComposite.cs
 */

using System.Collections.Generic;

namespace GameClient.CompositeAndInterpreter
{
	public class CheatComposite : CheatComponent
	{
		CheatComponent children;
		
		List <CheatComponent> cheats;
		
		public void AddCheat(CheatComponent cheat)
		{
		    cheats.Add(cheat);
		}

	    public CheatComposite(CheatComponent cheat)
	    {
	        children = cheat;
            cheats = new List<CheatComponent>();
	    }

	    public int[] getStats()
	    {
	        int[] stats = children.getStats();
	        foreach (CheatComponent cheat in cheats)
	        {
	            int[] s1 = cheat.getStats();
	            stats[0] += s1[0];
	            stats[1] += s1[1];
	            stats[2] += s1[2];
	            stats[3] += s1[3];
            }

	        return stats;
	    }
	}
	
}
