namespace ITHS_LABB_2_dungeon_crawler
{
    public abstract class Enemy : LevelElement
    {
        public string Name { get; set; }
        public int HP { get; set; }
        //public Dice AttackDice { get; set; }
        //public Dice DefenceDice { get; set; }
        public abstract void Update();

        public Enemy(int x, int y, char entityChar, ConsoleColor entityColor, string name, int hp) : base(x, y, entityChar, entityColor)
        {
            this.Name = name;
            this.HP = hp;
        }
    }
}
