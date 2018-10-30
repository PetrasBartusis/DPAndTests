/**
 * @(#) BuffEffect.cs
 */

namespace GameServer.Strategy
{
	public class BuffEffect : Effect
	{
		public void use( Player player )
		{
            player.setAttack(player.getAttack() + 1);
            player.setDefence(player.getDefence() + 1);
        }
		
	}
	
}
