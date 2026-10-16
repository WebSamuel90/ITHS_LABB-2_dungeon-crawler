using ITHS_LABB_2_dungeon_crawler.Interfaces;
using ITHS_LABB_2_dungeon_crawler.Models;

namespace ITHS_LABB_2_dungeon_crawler.Entities.Enemies
{
    public abstract class Enemy(Position Position, char Icon, ConsoleColor Color, string name, int hp, Dice attackDice, Dice defenceDice) : LevelElement(Position, Icon, Color), IMovable, IFightable
    {
        public string Name { get; } = name;
        private int currentHp = hp;
        public int HP { get => currentHp; set => currentHp = Math.Max(0, value); }
        public Dice AttackDice { get; set; } = attackDice;
        public Dice DefenceDice { get; set; } = defenceDice;
        public abstract Position Update(Position playerPosition);
    }
}
