namespace ITHS_LABB_2_dungeon_crawler
{
    public class Player : LevelElement
    {
        public string Name { get; } = "Player";
        public int HP { get; set; } = 100;
        public Player(int x, int y) : base(x, y, '@', ConsoleColor.Blue)
        {
        }
    }
}
