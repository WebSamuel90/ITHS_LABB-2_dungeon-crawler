namespace ITHS_LABB_2_dungeon_crawler
{
    public class Snake : Enemy
    {
        public Snake(int x, int y) : base(x, y, 's', ConsoleColor.DarkRed, "Snake", 25)
        {
        }

        public override void Update()
        {
            // Snake står still om spelaren är mer än 2 rutor bort, annars förflyttar den sig bort från spelaren.
            throw new NotImplementedException();
        }
    }
}
