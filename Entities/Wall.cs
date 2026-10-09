using ITHS_LABB_2_dungeon_crawler.Models;

namespace ITHS_LABB_2_dungeon_crawler
{
    public class Wall : LevelElement
    {
        public Wall(Position Position) : base(Position, '#', ConsoleColor.Gray)
        {
        }
    }
}
