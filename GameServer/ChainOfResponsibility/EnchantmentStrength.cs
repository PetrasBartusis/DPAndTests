using System;
using GameServer.Models;

namespace GameServer.ChainOfResponsibility
{
    public abstract class EnchantmentStrength
    {
        protected Player p;
        public int strength;
        protected EnchantmentStrength next;

        public EnchantmentStrength(Player p)
        {
            this.p = p;
        }

        public void addToPlayerStrength(int value)
        {
            if (strength == value)
            {
                Console.WriteLine("You got a {0} enchantment!", value);
                p.setAttack(p.getAttack() + strength);
                p.setDefence(p.getDefence() + strength);
            }
            else
            {
                Console.WriteLine("This is the not the correct enchantment");
                next.addToPlayerStrength(value);
            }
        }

        public void setNextChain(EnchantmentStrength next)
        {
            this.next = next;
        }
    }
}
