using ITHS_LABB_2_dungeon_crawler.Models;

namespace ITHS_LABB_2_dungeon_crawler.Entities.Loot
{
    public class HealthPotion(Position position) : Loot(position, 'h', ConsoleColor.Green, "Health potion", 10)
    {
        public override void Apply(Player player)
        {
            player.HP += Value;
        }
    }
}
