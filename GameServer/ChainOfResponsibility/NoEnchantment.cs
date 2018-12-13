using System;
using GameServer.Models;

namespace GameServer.ChainOfResponsibility
{
    public class NoEnchantment: EnchantmentStrength
    {
        public NoEnchantment(Player p) : base(p)
        {
            strength = 0;
        }
    }
}
