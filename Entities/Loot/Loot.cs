using ITHS_LABB_2_dungeon_crawler.Models;

namespace ITHS_LABB_2_dungeon_crawler.Entities.Loot
{
    public abstract class Loot(Position position, char icon, ConsoleColor color, string name, int value) : LevelElement(position, icon, color)
    {
        public string Name { get; } = name;
        public int Value { get; } = value;
        public abstract void Apply(Player player);
    }
}
