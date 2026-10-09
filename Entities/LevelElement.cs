using ITHS_LABB_2_dungeon_crawler.Models;

namespace ITHS_LABB_2_dungeon_crawler
{
    public abstract class LevelElement
    {
        public char Icon { get; protected set; }
        public ConsoleColor Color { get; protected set; }
        public Position Position { get; set; }

        protected LevelElement(Position position, char icon, ConsoleColor color)
        {
            this.Position = position;
            this.Icon = icon;
            this.Color = color;
        }

        public void Draw()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.ForegroundColor = Color;
            Console.Write(Icon);
            Console.ResetColor();
        }
    }
}
