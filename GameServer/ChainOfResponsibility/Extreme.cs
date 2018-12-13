using System;
using GameServer.Models;

namespace GameServer.ChainOfResponsibility
{
    public class ExtremeStrength : EnchantmentStrength
    {
       
        public ExtremeStrength(Player p) : base(p) {
            strength = 3;
        }
    }
}