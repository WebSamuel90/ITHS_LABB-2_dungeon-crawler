namespace ITHS_LABB_2_dungeon_crawler.Models
{
    public class Dice(int numberOfDices, int sidePersDice, int modifier = 0)
    {
        public int NumberOfDices { get; } = numberOfDices;
        public int SidesPerDice { get; } = sidePersDice;
        public int Modifier { get; private set; } = modifier;
        readonly static Random random = new();

        public int Throw()
        {
            int total = 0;

            for (int i = 0; i < NumberOfDices; i++)
            {
                total = total + random.Next(1, SidesPerDice + 1);
            }

            return total + Modifier;
        }

        public override string ToString()
        {
            string op = Modifier > 0 ? "+" : "";

            return Modifier != 0 ? $"{NumberOfDices}d{SidesPerDice}{op}{Modifier}" : $"{NumberOfDices}d{SidesPerDice}";
        }
    }
}
