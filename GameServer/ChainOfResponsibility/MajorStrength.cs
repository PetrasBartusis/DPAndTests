using System;
using GameServer.Models;

namespace GameServer.ChainOfResponsibility
{
    public class MajorStrength : EnchantmentStrength
    {
        Player p;
        public MajorStrength(Player p) : base(p) {
            strength = 2;
        }
    }
}
