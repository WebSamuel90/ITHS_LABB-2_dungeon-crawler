using ITHS_LABB_2_dungeon_crawler.Core;

namespace ITHS_LABB_2_dungeon_crawler.MenuBuilder
{
    public static class GameMenu
    {
        public static void Run()
        {
            bool running = true;

            while (running)
            {
                string[] menuOptions =
                {
                    "Normal Mode",
                    "Easy Mode",
                    "Exit"
                };

                int selection = ShowMenu(menuOptions);

                switch (selection)
                {
                    case 0:
                        RunLevelSelection(false);
                        break;

                    case 1:
                        RunLevelSelection(true);
                        break;

                    case 2:
                    case -1:
                        running = false;
                        break;
                }
            }
        }

        private static void RunLevelSelection(bool easyMode)
        {
            string[] levelOptions =
            {
                "Level 1",
                "Level 2 WIP",
                "Back"
            };

            bool selectingLevel = true;

            while (selectingLevel)
            {
                int selection = ShowMenu(levelOptions);

                switch (selection)
                {
                    case 0:
                        StartGame("Level1.txt", easyMode);
                        break;

                    case 1:
                        // Level 2 is not available yet
                        //StartGame("Level2.txt", easyMode);
                        break;

                    case 2:
                    case -1:
                        selectingLevel = false;
                        break;
                }
            }
        }

        private static void StartGame(string levelFile, bool easyMode)
        {
            Console.Clear();

            var game = new Game(levelFile, easyMode);
            game.Run();

            Console.Clear();
        }

        public static bool PauseMenu()
        {
            string[] options = { "Resume Game", "Exit to Main Menu" };

            int selection = ShowMenu(options);

            return selection == 1 || selection == -1;
        }

        private static int ShowMenu(string[] options)
        {
            Console.Clear();

            var menu = new Menu(options, 1, 1);

            menu.ModifyMenuCentered();
            menu.CenterMenuToConsole();

            Console.CursorVisible = false;

            return menu.RunMenu();
        }
    }
}