/**
 * @(#) Effect.cs
 */
using GameServer.Models;
using GameServer.Visitor;

namespace GameServer.Strategy
{
	public interface Effect
	{
		void use(Player player, EffectStrength es);
		
	}
	
}
