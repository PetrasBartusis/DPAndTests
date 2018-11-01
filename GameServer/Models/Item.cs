

using GameServer.Strategy;
/**
* @(#) Item.cs
*/
namespace GameServer.Models
{
	public class Item
	{
		int id;

        public string name { get; private set; }
		
		int price;

        Effect effect;

        public void useEffect(Player player)
        {
            effect.use(player);
        }
		
        public Item(int id, string name, PotionType type, int price)
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
        }

	}
	
}
