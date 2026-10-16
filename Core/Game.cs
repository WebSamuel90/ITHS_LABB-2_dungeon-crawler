using ITHS_LABB_2_dungeon_crawler.Entities;
using ITHS_LABB_2_dungeon_crawler.Entities.Enemies;
using ITHS_LABB_2_dungeon_crawler.MenuBuilder;
using ITHS_LABB_2_dungeon_crawler.Models;
using ITHS_LABB_2_dungeon_crawler.Rendering;

namespace ITHS_LABB_2_dungeon_crawler.Core
{
    public class Game
    {
        private LevelData level;
        private Player player;
        private readonly int initialEnemyCount;
        private int gameTurn;
        private bool playGame;
        private bool bossSpawned = false;
        private Boss? boss;
        private Door door;
        private bool doorUnlocked = false;


        public Game(string levelFile, bool easyMode)
        {
            GameRenderer.ReserLevel();
            level = new LevelData();
            level.LoadLevel(
                Path.Combine(AppContext.BaseDirectory, "Assets", levelFile)
            );

            player = new Player(level.PlayerStartPosition);
            if (easyMode)
            {
                player.AttackDice.IncreaseModifier(10);
                player.DefenceDice.IncreaseModifier(10);
            }
            initialEnemyCount = level.Elements.OfType<Enemy>().Count();

            Position doorPosition = new(4, 6);
            door = new Door(doorPosition, 'D', ConsoleColor.DarkGray);

            level.Elements.Add(player);
            level.Elements.Add(door);


            gameTurn = 0;

            playGame = true;
        }

        public void Run()
        {

            Console.CursorVisible = false;
            GameRenderer.ClearLog();



            while (playGame)
            {
                GameRenderer.PlayerHUD(player, gameTurn, initialEnemyCount, bossSpawned);

                GameRenderer.DrawLevel(player, level.Elements);

                ConsoleKey key = Console.ReadKey(true).Key;
                Position? targetPosition = player.TakeInput(key);

                GameRenderer.ClearLog();


                if (key == ConsoleKey.Escape)
                {
                    bool exitGame = GameMenu.PauseMenu();

                    if (exitGame)
                    {
                        playGame = false;
                    }

                    continue;
                }

                if (targetPosition.HasValue)
                {
                    var turnSpent = level.TryMove(player, targetPosition.Value);

                    if (turnSpent)
                    {
                        gameTurn++;
                        foreach (var element in level.Elements.ToList())
                        {
                            if (element is Enemy enemy)
                            {
                                var enemyTargetPosition = enemy.Update(player.Position);
                                level.TryMove(enemy, enemyTargetPosition);
                            }
                        }
                    }
                }

                if (!doorUnlocked && player.EnemiesSlain >= 1)
                {
                    level.Elements.Remove(door);
                    doorUnlocked = true;
                    GameRenderer.DoorUnlocked();
                }

                if (!bossSpawned && player.EnemiesSlain == initialEnemyCount)
                {
                    Position bossPosition = new(21, 3);
                    boss = new Boss(bossPosition);
                    level.Elements.Add(boss);
                    bossSpawned = true;
                    GameRenderer.BossSpawnLog();
                }

                if (boss is not null && boss.HP <= 0)
                {
                    GameRenderer.GameEnding("Congratulations, you beat the level!");
                    Thread.Sleep(3500);
                    playGame = false;
                }

                if (player.HP == 0)
                {
                    GameRenderer.GameEnding("GAME OVER");
                    Thread.Sleep(3500);
                    playGame = false;
                }
            }
        }
    }
}
