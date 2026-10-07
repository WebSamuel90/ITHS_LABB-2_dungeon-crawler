namespace ITHS_LABB_2_dungeon_crawler
{
    public abstract class LevelElement
    {
        public int xPosition { get; set; }
        public int yPosition { get; set; }
        public char entityChar { get; set; }
        public ConsoleColor entityColor { get; set; }

        public LevelElement(int x, int y, char entityChar, ConsoleColor entityColor)
        {
            this.xPosition = x;
            this.yPosition = y;
            this.entityChar = entityChar;
            this.entityColor = entityColor;
        }

        public void Draw()
        {
            Console.SetCursorPosition(xPosition, yPosition);
            Console.ForegroundColor = entityColor;
            Console.Write(entityChar);
            Console.ResetColor();
        }
    }
}
