using ITHS_LABB_2_dungeon_crawler.Entities;
using ITHS_LABB_2_dungeon_crawler.Entities.Loot;
using ITHS_LABB_2_dungeon_crawler.Interfaces;
using ITHS_LABB_2_dungeon_crawler.Models;

namespace ITHS_LABB_2_dungeon_crawler.Rendering
{
    public static class GameRenderer
    {
        private static readonly List<Position> previousDynamicPositions = [];
        const int playerHUDSCursorStartLeft = 2;
        const int logCursorStartLeft = 25;
        public static void PlayerHUD(Player player, int gameTurn, int initialEnemyCount, bool bossSpawned)
        {
            GameRenderer.DrawBox(0, 0, 21, 7);
            Console.SetCursorPosition(playerHUDSCursorStartLeft, 1);
            Console.WriteLine($"{player.Name} HP: {player.HP}/100");
            Console.SetCursorPosition(playerHUDSCursorStartLeft, 2);
            Console.WriteLine($"ATK: {player.AttackDice.Modifier} DEF: {player.DefenceDice.Modifier}");
            Console.SetCursorPosition(playerHUDSCursorStartLeft, 3);
            Console.WriteLine($"Enemies slain: {player.EnemiesSlain}/{initialEnemyCount}");
            Console.SetCursorPosition(playerHUDSCursorStartLeft, 4);
            Console.WriteLine($"Boss spawned: {(bossSpawned ? "Yes" : "No")}");
            Console.SetCursorPosition(playerHUDSCursorStartLeft, 5);
            Console.WriteLine($"Game turn: {gameTurn}");
        }

        public static void CombatLog(IFightable attacker, IFightable defender, bool aggressor, int attackRoll, int defenceRoll, int damage)
        {
            string attackLabel = aggressor ? "attacks" : "counterattacks";

            Console.SetCursorPosition(logCursorStartLeft, aggressor ? 1 : 3);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"{attacker.Name} {attackLabel} {defender.Name}!");

            Console.SetCursorPosition(logCursorStartLeft + 2, aggressor ? 2 : 4);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"ATK ({attacker.AttackDice}): {attackRoll} vs DEF ({defender.DefenceDice}): {defenceRoll} => {damage} damage!");
            Console.ResetColor();
        }

        public static void LootLog(IFightable fighter, Loot loot)
        {
            Console.SetCursorPosition(logCursorStartLeft, 6);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{fighter.Name} dropped {(loot.Name == "Attack buff" ? "an" : "a")} {loot.Name}!");
            Console.ResetColor();
        }

        public static void DeathLog(IFightable fighter)
        {
            if (fighter is Player)
            {
                Console.SetCursorPosition(logCursorStartLeft, 5);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You have been slain!");
                Console.SetCursorPosition(logCursorStartLeft, 6);
                Console.WriteLine("GAME OVER");
                Console.ResetColor();
            }
            else
            {
                Console.SetCursorPosition(logCursorStartLeft + 2, 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{fighter.Name} has been slain!");
                Console.ResetColor();
            }
        }

        public static void BossSpawnLog()
        {
            Console.SetCursorPosition(logCursorStartLeft, 7);
            Console.WriteLine("All enemies defeated! The boss has appeared!");
        }

        public static void DoorUnlocked()
        {
            Console.SetCursorPosition(logCursorStartLeft, 7);
            Console.WriteLine("A door have been unlocked! (D)");
        }

        public static void GameEnding(string text)
        {
            int x = Math.Max(0, (Console.WindowWidth - text.Length) / 2);
            ClearLevel();
            Console.SetCursorPosition(x, Console.WindowHeight / 2);
            Console.WriteLine(text);
        }

        public static void DrawBox(int x, int y, int width, int height)
        {
            Console.SetCursorPosition(x, y);
            Console.Write($"┌{new string('─', width)}┐");

            for (int h = 0; h < height; h++)
            {
                Console.SetCursorPosition(x, y + h + 1);
                Console.Write($"|{new string(' ', width)}|");
            }

            Console.SetCursorPosition(x, y + height + 1);
            Console.Write($"└{new string('─', width)}┘");
        }

        public static void ClearLog()
        {
            DrawBox(23, 0, 51, 7);
        }

        private static void ClearLevel()
        {
            for (int y = LevelElement.levelYOffset; y < LevelElement.levelYOffset + 18; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write(new string(' ', Console.WindowWidth - 1));
            }
        }

        private static void ClearDynamicEntities()
        {
            foreach (var position in previousDynamicPositions)
            {
                Console.SetCursorPosition(
                    position.X,
                    position.Y + LevelElement.levelYOffset);

                Console.Write(' ');
            }
            previousDynamicPositions.Clear();
        }

        public static void ReserLevel()
        {
            previousDynamicPositions.Clear();
        }


        public static void DrawLevel(Player player, IEnumerable<LevelElement> elements)
        {
            const int visionRange = 5;

            ClearDynamicEntities();

            player.Draw();

            foreach (var element in elements)
            {
                double distance = LevelElement.GetDistanceBetween(player.Position, element.Position);


                if (element is Wall wall)
                {
                    if (distance <= visionRange)
                    {
                        wall.IsDiscovered = true;
                    }
                    if (wall.IsDiscovered)
                    {
                        wall.Draw();
                    }
                }
                else if (distance <= visionRange)
                {
                    element.Draw();

                    previousDynamicPositions.Add(element.Position);
                }
            }
        }
    }
}
