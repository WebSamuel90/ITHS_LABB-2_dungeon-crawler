using ITHS_LABB_2_dungeon_crawler.Models;

namespace ITHS_LABB_2_dungeon_crawler.Entities
{
    public class Rat(Position Position) : Enemy(Position, 'r', ConsoleColor.DarkYellow, "Rat", 10, new Dice(1, 6, 3), new Dice(1, 6, 1))
    {
        static readonly Random random = new();
        public override Position Update(Position playerPosition)
        {
            int newMove = random.Next(4);
            Position newPosition = new(Position.X, Position.Y);

            switch (newMove)
            {
                case 0:
                    newPosition.Y--;
                    break;
                case 1:
                    newPosition.Y++;
                    break;
                case 2:
                    newPosition.X--;
                    break;
                case 3:
                    newPosition.X++;
                    break;
            }

            return newPosition;
        }
    }
}
