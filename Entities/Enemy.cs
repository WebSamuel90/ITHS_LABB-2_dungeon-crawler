using ITHS_LABB_2_dungeon_crawler.Interfaces;
using ITHS_LABB_2_dungeon_crawler.Models;

namespace ITHS_LABB_2_dungeon_crawler
{
    public abstract class Enemy : LevelElement, IMovable
    {
        public string Name { get; private set; }
        public int HP { get; set; }
        //public Dice AttackDice { get; set; }
        //public Dice DefenceDice { get; set; }
        public abstract void Update();

        protected Enemy(Position Position, char Icon, ConsoleColor Color, string name, int hp) : base(Position, Icon, Color)
        {
            this.Name = name;
            this.HP = hp;
        }
    }
}
