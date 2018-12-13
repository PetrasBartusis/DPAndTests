

using GameServer.Models;
using GameServer.Visitor;
/**
* @(#) BuffEffect.cs
*/
namespace GameServer.Strategy
{
	public class BuffEffect : Effect
	{

        public void use(Player player, EffectStrength es)
        {
            int strength = es.calculateStrength(this);
            player.setAttack(player.getAttack() + strength);
            player.setDefence(player.getDefence() + strength);
        }
    }
	
}
