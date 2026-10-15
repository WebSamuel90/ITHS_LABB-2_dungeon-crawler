using ITHS_LABB_2_dungeon_crawler.Entities;
using ITHS_LABB_2_dungeon_crawler.Game;
using ITHS_LABB_2_dungeon_crawler.Interfaces;
using ITHS_LABB_2_dungeon_crawler.Models;

namespace ITHS_LABB_2_dungeon_crawler
{
    public class LevelData
    {
        private readonly List<LevelElement> elements = [];
        public List<LevelElement> Elements => elements;
        public Position PlayerStartPosition { get; private set; }

        public void LoadLevel(string filename)
        {

            if (string.IsNullOrWhiteSpace(filename) || !File.Exists(filename))
            {
                throw new ArgumentException("Invalid filename or file does not exist.", nameof(filename));
            }

            string[] levelArray = File.ReadAllLines(filename);

            for (int y = 0; y < levelArray.GetLength(0); y++)
            {
                for (int x = 0; x < levelArray[y].Length; x++)
                {
                    char entityChar = levelArray[y][x];
                    Position currentPosition = new(x, y);
                    switch (entityChar)
                    {
                        case '#':
                            elements.Add(new Wall(currentPosition));
                            break;
                        case '@':
                            PlayerStartPosition = currentPosition;
                            break;
                        case 'r':
                            elements.Add(new Rat(currentPosition));
                            break;
                        case 's':
                            elements.Add(new Snake(currentPosition));
                            break;
                        default:
                            continue;
                    }
                }
            }
        }

        public bool TryMove(IMovable movable, Position newPosition)
        {
            var elementAtNewPosition = Elements.SingleOrDefault(e => e.Position.X == newPosition.X && e.Position.Y == newPosition.Y);
            switch (elementAtNewPosition)
            {
                case Wall:
                    return false;
                case Enemy:
                    if (movable is Player)
                    {
                        HandleCombat((IFightable)movable, (IFightable)elementAtNewPosition);
                        return true;
                    }
                    return false;
                case Player:
                    if (movable is Enemy)
                    {
                        HandleCombat((IFightable)movable, (IFightable)elementAtNewPosition);
                    }
                    break;
                case null:
                    Console.SetCursorPosition(movable.Position.X, movable.Position.Y + LevelElement.levelYOffset);
                    Console.Write(" ");
                    movable.Position = newPosition;
                    return true;
            }

            return false;
        }

        private void HandleCombat(IFightable attacker, IFightable defender)
        {
            Combat.Fight(attacker, defender);

            if (defender is Enemy && defender.HP <= 0)
            {
                elements.Remove((LevelElement)defender);

                if (attacker is Player player)
                {
                    player.IncreaseEnemiesSlain();
                }
            }
        }
    }
}
