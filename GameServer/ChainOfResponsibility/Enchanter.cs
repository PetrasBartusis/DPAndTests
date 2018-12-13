using System;
using GameServer.Models;

namespace GameServer.ChainOfResponsibility
{
    public class Enchanter
    {
        EnchantmentStrength minorE;
        EnchantmentStrength majorE;
        EnchantmentStrength extremeE;
        EnchantmentStrength noEnchantment;
        Player p;
        public int enchantmentCost = 500;

        public Enchanter(Player p)
        {
            this.p = p;
            minorE = new MinorStrength(p);
            majorE = new MajorStrength(p);
            extremeE = new ExtremeStrength(p);
            noEnchantment = new NoEnchantment(p);
            minorE.setNextChain(majorE);
            majorE.setNextChain(extremeE);
            extremeE.setNextChain(noEnchantment);
        }

        public void startEnchantment()
        {
            Random s_Random = new Random();
            int perCent = s_Random.Next(0, 100);

            EnchantmentStrength main = minorE;

            if(perCent < 30){
                main.addToPlayerStrength(3);
            } else if(perCent <60){
                main.addToPlayerStrength(2);
            } else if(perCent < 90){
                main.addToPlayerStrength(1);
            } else {
                main.addToPlayerStrength(0);
            }
            p.gold -= enchantmentCost;
        }
    }
}
