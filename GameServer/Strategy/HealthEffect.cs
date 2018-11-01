

using GameServer.Models;
/**
* @(#) HealthEffect.cs
*/
namespace GameServer.Strategy
{
	public class HealthEffect : Effect
	{
        public void use(Player player)
        {
            //heal player for 5
            if(player.getMaxHp() < player.getHp() + 5)
            {
                player.setHp(player.getMaxHp());
            } else
            {
                player.setHp(player.getHp() + 5);
            }
        }
    }
	
}
