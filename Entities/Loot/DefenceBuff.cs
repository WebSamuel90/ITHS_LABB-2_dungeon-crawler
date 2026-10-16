using ITHS_LABB_2_dungeon_crawler.Models;

namespace ITHS_LABB_2_dungeon_crawler.Entities.Loot
{
    public class DefenceBuff(Position position) : Loot(position, 'd', ConsoleColor.Cyan, "Defence buff", 1)
    {
        public override void Apply(Player player)
        {
            player.DefenceDice.IncreaseModifier(Value);
        }
    }
}
