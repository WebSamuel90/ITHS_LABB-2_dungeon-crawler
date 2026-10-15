using ITHS_LABB_2_dungeon_crawler.Interfaces;
using ITHS_LABB_2_dungeon_crawler.Models;

namespace ITHS_LABB_2_dungeon_crawler.Entities
{
    public class Player(Position Position) : LevelElement(Position, '@', ConsoleColor.Blue), IMovable, IFightable
    {
        public string Name { get; } = "Player";
        public int HP { get; set; } = 100;
        public Dice AttackDice { get; } = new Dice(2, 6, 2);
        public Dice DefenceDice { get; } = new Dice(2, 6, 0);
        public int EnemiesSlain { get; private set; } = 0;

        public void IncreaseEnemiesSlain()
        {
            EnemiesSlain++;
        }

        public Position? TakeInput()
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
                    return null;
            }

            return newPosition;
        }
    }
}
