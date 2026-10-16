using ITHS_LABB_2_dungeon_crawler.Interfaces;
using ITHS_LABB_2_dungeon_crawler.Models;

namespace ITHS_LABB_2_dungeon_crawler.Entities
{
    public class Boss(Position position) : LevelElement(position, 'B', ConsoleColor.Red), IFightable
    {
        public string Name { get; } = "Boss";
        private int hp = 100;
        public int HP { get => hp; set => hp = Math.Clamp(value, 0, hp); }
        public Dice AttackDice { get; } = new Dice(2, 6, 2);
        public Dice DefenceDice { get; } = new Dice(2, 6, 0);
    }
}
