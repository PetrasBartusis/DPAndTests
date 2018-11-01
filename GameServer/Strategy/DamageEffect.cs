

using System;
using GameServer.Models;
/**
* @(#) DamageEffect.cs
*/
namespace GameServer.Strategy
{
	public class DamageEffect : Effect
	{
		public void use(Player player )
		{
            Console.WriteLine("All enemies are immune to damage potion at the moment! :o");
		}
		
	}
	
}
