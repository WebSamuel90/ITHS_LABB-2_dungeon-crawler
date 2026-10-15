using ITHS_LABB_2_dungeon_crawler.Entities;
using ITHS_LABB_2_dungeon_crawler.Rendering;

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
            int initialEnemyCount = levelOne.Elements.OfType<Enemy>().Count();


            levelOne.Elements.Add(player);

            int gameTurn = 0;

            bool playGame = true;

            Console.CursorVisible = false;
            GameRenderer.ClearLog();

            while (playGame)
            {
                GameRenderer.PlayerHUD(player, gameTurn, initialEnemyCount);

                GameRenderer.DrawLevel(player, levelOne.Elements);

                var targetPosition = player.TakeInput();

                GameRenderer.ClearLog();
                if (targetPosition.HasValue)
                {
                    var turnSpent = levelOne.TryMove(player, targetPosition.Value);

                    if (turnSpent)
                    {
                        gameTurn++;
                        foreach (var element in levelOne.Elements.ToList())
                        {
                            if (element is Enemy enemy)
                            {
                                var enemyTargetPosition = enemy.Update(player.Position);
                                levelOne.TryMove(enemy, enemyTargetPosition);
                            }
                        }
                    }
                }
            }
        }
    }
}
