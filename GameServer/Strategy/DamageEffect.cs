

using System;
using GameServer.Models;
using GameServer.Visitor;
/**
* @(#) DamageEffect.cs
*/
namespace GameServer.Strategy
{
	public class DamageEffect : Effect
	{

        public void use(Player player, EffectStrength es)
        {
            Console.WriteLine("All enemies are immune to damage potion at the moment! :o");
        }
    }
	
}
