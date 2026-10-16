using ITHS_LABB_2_dungeon_crawler.Models;

namespace ITHS_LABB_2_dungeon_crawler.Entities.Loot
{
    public class AttackBuff(Position position) : Loot(position, 'a', ConsoleColor.Blue, "Attack buff", 1)
    {
        public override void Apply(Player player)
        {
            player.AttackDice.IncreaseModifier(Value);
        }
    }
}
