namespace ITHS_LABB_2_dungeon_crawler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var levelOne = new LevelData();
            levelOne.LoadLevel(
                Path.Combine(AppContext.BaseDirectory, "Assets", "Level1.txt")
            );

            var player = new Player(levelOne.PlayerStartXPosition, levelOne.PlayerStartYPositiion);

            foreach (var element in levelOne.Elements)
            {
                element.Draw();
            }
            player.Draw();

            bool playGame = true;


            while (playGame)
            {
                player.TryMove(levelOne.Elements);
            }


        }
    }
}
