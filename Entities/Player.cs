namespace ITHS_LABB_2_dungeon_crawler
{
    public class Player : LevelElement
    {
        public string Name { get; } = "Player";
        public int HP { get; set; } = 100;
        public Player(int x, int y) : base(x, y, '@', ConsoleColor.Blue)
        {
        }

        public void TryMove(IEnumerable<LevelElement> levelElements)
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo KeyInfo = Console.ReadKey();
            int newX = xPosition;
            int newY = yPosition;

            switch (KeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    newY--;
                    break;
                case ConsoleKey.DownArrow:
                    newY++;
                    break;
                case ConsoleKey.LeftArrow:
                    newX--;
                    break;
                case ConsoleKey.RightArrow:
                    newX++;
                    break;
                default:
                    break;
            }

            var elementAtNewPosition = levelElements
                .Where(e => e.xPosition == newX && e.yPosition == newY)
                .FirstOrDefault();

            switch (elementAtNewPosition)
            {
                case Wall:
                    break;
                case Enemy:
                    // Todo: Attack enemy.
                    break;
                default:
                    ClearPreviousPosition(xPosition, yPosition);
                    xPosition = newX;
                    yPosition = newY;
                    this.Draw();
                    break;
            }
        }
    }
}
