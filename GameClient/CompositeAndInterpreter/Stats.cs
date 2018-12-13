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
        public Stats(int s)
        {
            stats[0] = s;
            stats[1] = s;
            stats[2] = s;
            stats[3] = s;
        }
    }
}
