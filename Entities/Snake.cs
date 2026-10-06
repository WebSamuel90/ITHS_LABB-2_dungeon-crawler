namespace ITHS_LABB_2_dungeon_crawler
{
    public class Snake : Enemy
    {
        public Snake(int x, int y) : base(x, y, 's', ConsoleColor.DarkRed, "Snake", 25)
        {
        }

        public override void Update()
        {
            // Om spelaren finns inom 2x2 rutan runt ormen, så ska ormen flytta sig ifrån spelaren. Annars ska den stå still. Om ormen försöker flytta sig till en plats där det redan finns en vägg eller en annan fiende ska den inte flytta sig alls.
            throw new NotImplementedException();
        }
    }
}
