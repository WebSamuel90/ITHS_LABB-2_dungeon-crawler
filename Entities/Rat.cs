namespace ITHS_LABB_2_dungeon_crawler
{
    public class Rat : Enemy
    {
        public Rat(int x, int y) : base(x, y, 'r', ConsoleColor.DarkYellow, "Rat", 10)
        {
        }

        public override void Update()
        {
            // Om spelaren finns inom 5x5 rutan runt råttan, så ska råttan flytta sig ett steg mot spelaren. Annars ska den flytta sig slumpmässigt ett steg i slumpmässig riktning (upp, ner, vänster, höger). Om råttan försöker flytta sig till en plats där det redan finns en vägg eller en annan fiende ska den inte flytta sig alls. Om råttan försöker flytta sig till en plats där spelaren står ska den attackera spelaren istället för att flytta sig.
            throw new NotImplementedException();
        }
    }
}
