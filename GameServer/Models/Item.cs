

using GameServer.Strategy;
using GameServer.Visitor;
using System;
using System.Text;
/**
* @(#) Item.cs
*/
namespace GameServer.Models
{
	public class Item : ICloneable
	{
		int id;

        public string name { get; private set; }
		
		int price;

        Effect effect;

        EffectStrength es;

        public void useEffect(Player player)
        {
            effect.use(player, es);
        }
		
        public Item(int id, string name, PotionType type, int price, EffectStrength es)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            switch (type)
            {
                case PotionType.health:
                    effect = new HealthEffect();
                    break;
                case PotionType.buff:
                    effect = new BuffEffect();
                    break;
                case PotionType.damage:
                    effect = new DamageEffect();
                    break;
                default:
                    effect = new HealthEffect();
                    break;
            }
            this.es = es;
        }

        public override string ToString()
        {
            return new StringBuilder("Item name = ").Append(name).Append(", price = ").Append(price).ToString();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
            // TODO copy effects
        }
    }
	
}
