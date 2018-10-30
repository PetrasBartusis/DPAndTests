/**
 * @(#) Item.cs
 */

namespace GameServer.Strategy
{
	public class Item
	{
		int id;

        string name;
		
		int price;

        Effect effect;

        public void useEffect(Player player)
        {
            effect.use(player);
        }
		
        public Item(int id, string name)
        {
            this.id = id;
            this.name = name;
            switch (name)
            {
                case "hp potion":
                    effect = new HealthEffect();
                    break;
                case "buff potion":
                    effect = new BuffEffect();
                    break;
                case "damage potion":
                    effect = new DamageEffect();
                    break;
                default:
                    effect = new HealthEffect();
                    break;
            }
        }
        
        public string getName()
        {
            return name;
        }
	}
	
}
