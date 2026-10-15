using ITHS_LABB_2_dungeon_crawler.Models;

namespace ITHS_LABB_2_dungeon_crawler.Interfaces
{
    public interface IFightable
    {
        public string Name { get; }
        public int HP { get; set; }
        public Dice AttackDice { get; }
        public Dice DefenceDice { get; }
    }
}
