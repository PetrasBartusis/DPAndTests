

using GameServer.Models;
using GameServer.Visitor;
/**
* @(#) HealthEffect.cs
*/
namespace GameServer.Strategy
{
	public class HealthEffect : Effect
	{

        public void use(Player player, EffectStrength es)
        {
            //heal player for 5
            int strength = es.calculateStrength(this);
            if (player.getMaxHp() < player.getHp() + strength)
            {
                player.setHp(player.getMaxHp());
            }
            else
            {
                player.setHp(player.getHp() + strength);
            }
        }
    }
	
}
