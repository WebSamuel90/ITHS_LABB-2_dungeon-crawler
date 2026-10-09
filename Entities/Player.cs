using ITHS_LABB_2_dungeon_crawler.Interfaces;
using ITHS_LABB_2_dungeon_crawler.Models;

namespace ITHS_LABB_2_dungeon_crawler
{
    public class Player : LevelElement, IMovable
    {
        public string Name { get; } = "Player";
        public int HP { get; set; } = 100;
        public Player(Position Position) : base(Position, '@', ConsoleColor.Blue)
        {
        }

        public Position TakeInput()
        {
            ConsoleKeyInfo KeyInfo = Console.ReadKey(true);
            Position newPosition = new(Position.X, Position.Y);

            switch (KeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    newPosition.Y--;
                    break;
                case ConsoleKey.DownArrow:
                    newPosition.Y++;
                    break;
                case ConsoleKey.LeftArrow:
                    newPosition.X--;
                    break;
                case ConsoleKey.RightArrow:
                    newPosition.X++;
                    break;
                default:
                    break;
            }

            return newPosition;
        }
    }
}
