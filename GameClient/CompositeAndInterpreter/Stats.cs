/**
 * @(#) Stats.cs
 */


namespace GameClient.CompositeAndInterpreter
{
    public class Stats : CheatComponent
    {
        int[] stats = {0, 0, 0, 0};

        public int[] getStats()
        {
            return stats;
        }

        public Stats(int hp, int att, int def, int money)
        {
            stats[0] = hp;
            stats[1] = att;
            stats[2] = def;
            stats[3] = money;
        }
    }
}
