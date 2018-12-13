using System;
using GameServer.Models;

namespace GameServer.ChainOfResponsibility
{
    public class MinorStrength: EnchantmentStrength
    {
        public MinorStrength(Player p):base(p){
            strength = 1;
        }
    }
}
