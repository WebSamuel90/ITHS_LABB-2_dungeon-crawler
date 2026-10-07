namespace ITHS_LABB_2_dungeon_crawler
{
    public class Rat : Enemy
    {
        public Rat(int x, int y) : base(x, y, 'r', ConsoleColor.DarkYellow, "Rat", 10)
        {
        }

        public override void Update()
        {
            // Rat förflyttar sig 1 steg i slumpmässig vald riktning (upp, ner, höger eller vänster) varje omgång
            throw new NotImplementedException();
        }
    }
}
