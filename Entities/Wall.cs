using ITHS_LABB_2_dungeon_crawler.Entities;
using ITHS_LABB_2_dungeon_crawler.Models;

namespace ITHS_LABB_2_dungeon_crawler
{
    public class Wall(Position Position) : LevelElement(Position, '#', ConsoleColor.Gray)
    {
        public bool IsDiscovered { get; set; } = false;
    }
}
