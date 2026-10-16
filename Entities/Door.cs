using ITHS_LABB_2_dungeon_crawler.Models;

namespace ITHS_LABB_2_dungeon_crawler.Entities
{
    public class Door : LevelElement
    {
        public string Name { get; } = "Door";
        public Door(Position position, char icon, ConsoleColor color) : base(position, icon, color)
        {
        }
    }
}
