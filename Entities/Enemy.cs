using ITHS_LABB_2_dungeon_crawler.Interfaces;
using ITHS_LABB_2_dungeon_crawler.Models;

namespace ITHS_LABB_2_dungeon_crawler.Entities
{
    public abstract class Enemy(Position Position, char Icon, ConsoleColor Color, string name, int hp, Dice attackDice, Dice defenceDice) : LevelElement(Position, Icon, Color), IMovable, IFightable
    {
        public string Name { get; } = name;
        public int HP { get; set; } = hp;
        public Dice AttackDice { get; set; } = attackDice;
        public Dice DefenceDice { get; set; } = defenceDice;
        public abstract Position Update(Position playerPosition);
    }
}
