/**
 * @(#) Cheat.cs
 */

using System;
using GameServer.Models;

namespace GameClient.CompositeAndInterpreter
{
	public class Cheat
	{
		
		public Player lifeCheat( Player p, int s )
		{
            CheatComponent cheat = new AddLife(playerToStats(p), new Stats(s));
		    return setPlayerStats(p, cheat.getStats());
        }
	    public Player defenceCheat(Player p, int s)
	    {
	        CheatComponent cheat = new AddDefence(playerToStats(p), new Stats(s));
	        return setPlayerStats(p, cheat.getStats());
        }
	    public Player attackCheat(Player p, int s)
	    {
	        CheatComponent cheat = new AddAttack(playerToStats(p), new Stats(s));
	        return setPlayerStats(p, cheat.getStats());
        }
	    public Player moneyCheat(Player p, int s)
	    {
	        CheatComponent cheat = new AddMoney(playerToStats(p), new Stats(s));

            return setPlayerStats(p, cheat.getStats());
	    }

	    public Player allCheats(Player p, int s)
	    {

	        CheatComposite cheat = new CheatComposite(playerToStats(p));
	        CheatComponent c1 = new AddLife(emptyStats(), new Stats(s));
	        CheatComponent c2 = new AddAttack(emptyStats(), new Stats(s));
	        CheatComponent c3 = new AddDefence(emptyStats(), new Stats(s));
	        CheatComponent c4 = new AddMoney(emptyStats(), new Stats(s));

            cheat.AddCheat(c1);
	        cheat.AddCheat(c2);
	        cheat.AddCheat(c3);
	        cheat.AddCheat(c4);

	        return setPlayerStats(p, cheat.getStats());
        }


	    private CheatComponent playerToStats(Player p)
	    {
            CheatComponent stats = new Stats(p.getMaxHp(), p.getAttack(), p.getDefence(), p.getGold());
	        return stats;
	    }

	    private Player setPlayerStats(Player p, int[] stats)
	    {
	        p.setHp(stats[0]);
	        p.setAttack(stats[1]);
	        p.setDefence(stats[2]);
	        p.setGold(stats[3]);
	        p.seMaxHp(stats[0]);
	        return p;
	    }

	    private CheatComponent emptyStats()
	    {
            return new Stats(0, 0, 0, 0);
	    }
	}
	
}
