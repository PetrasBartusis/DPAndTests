/**
 * @(#) Effect.cs
 */
using GameServer.Models;

namespace GameServer.Strategy
{
	public interface Effect
	{
		void use(Player player);
		
	}
	
}
