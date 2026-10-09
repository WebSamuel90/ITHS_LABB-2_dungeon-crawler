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

            var player = new Player(levelOne.PlayerStartPosition);

            bool playGame = true;

            Console.CursorVisible = false;

            while (playGame)
            {
                player.Draw();
                foreach (var element in levelOne.Elements)
                {
                    element.Draw();
                }

                var desiredPosition = player.TakeInput();
                levelOne.TryMove(player, desiredPosition);
            }


        }
    }
}
