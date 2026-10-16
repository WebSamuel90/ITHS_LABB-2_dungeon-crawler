using ITHS_LABB_2_dungeon_crawler.Models;

namespace ITHS_LABB_2_dungeon_crawler.Entities
{
    public abstract class LevelElement(Position position, char icon, ConsoleColor color)
    {
        public char Icon { get; protected set; } = icon;
        public ConsoleColor Color { get; protected set; } = color;
        public Position Position { get; set; } = position;

        public const int levelYOffset = 9;

        public void Draw()
        {
            Console.SetCursorPosition(Position.X, Position.Y + levelYOffset);
            Console.ForegroundColor = Color;
            Console.Write(Icon);
            Console.ResetColor();
        }

        public static double GetDistanceBetween(Position entityOne, Position entityTwo)
        {
            return Math.Sqrt(Math.Pow(entityOne.Y - entityTwo.Y, 2) + Math.Pow(entityOne.X - entityTwo.X, 2));
        }
    }
}
