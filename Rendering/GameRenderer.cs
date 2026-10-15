using ITHS_LABB_2_dungeon_crawler.Entities;
using ITHS_LABB_2_dungeon_crawler.Interfaces;

namespace ITHS_LABB_2_dungeon_crawler.Rendering
{
    public static class GameRenderer
    {
        public static void PlayerHUD(Player player, int gameTurn, int initialEnemyCount)
        {
            GameRenderer.DrawBox(0, 0, 20, 6);
            Console.SetCursorPosition(2, 1);
            Console.WriteLine($"{player.Name} HP: {player.HP}/100");
            Console.SetCursorPosition(2, 2);
            Console.WriteLine($"ATK: {player.AttackDice.Modifier} DEF: {player.DefenceDice.Modifier}");
            Console.SetCursorPosition(2, 3);
            Console.WriteLine($"Enemies slain: {player.EnemiesSlain}/{initialEnemyCount}");
            Console.SetCursorPosition(2, 4);
            Console.WriteLine($"Game turn: {gameTurn}");
        }

        public static void CombatLog(IFightable attacker, IFightable defender, bool aggressor, int attackRoll, int defenceRoll, int damage)
        {
            string attackLabel = aggressor ? "attacks" : "counterattacks";

            Console.SetCursorPosition(24, aggressor ? 1 : 3);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"{attacker.Name} {attackLabel} {defender.Name}!");

            Console.SetCursorPosition(24, aggressor ? 2 : 4);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  ATK ({attacker.AttackDice}): {attackRoll} vs DEF ({defender.DefenceDice}): {defenceRoll} => {damage} damage!");
            Console.ResetColor();
        }

        public static void DeathLog(IFightable fighter)
        {
            if (fighter is Player)
            {
                Console.SetCursorPosition(24, 5);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You have been slain!");
                Console.SetCursorPosition(24, 6);
                Console.WriteLine("GAME OVER");
                Console.ResetColor();
            }
            else
            {
                Console.SetCursorPosition(24, 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"  {fighter.Name} has been slain!");
                Console.ResetColor();
            }
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
            DrawBox(22, 0, 50, 6);
        }

        private static void ClearLevel()
        {
            for (int y = LevelElement.levelYOffset; y < LevelElement.levelYOffset + 18; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write(new string(' ', Console.WindowWidth - 1));
            }
        }


        public static void DrawLevel(Player player, IEnumerable<LevelElement> elements)
        {
            const int visionRange = 5;

            ClearLevel();

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
                }
            }
        }
    }
}
