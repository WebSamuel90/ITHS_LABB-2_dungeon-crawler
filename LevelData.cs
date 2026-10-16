using ITHS_LABB_2_dungeon_crawler.Core;
using ITHS_LABB_2_dungeon_crawler.Entities;
using ITHS_LABB_2_dungeon_crawler.Entities.Enemies;
using ITHS_LABB_2_dungeon_crawler.Entities.Loot;
using ITHS_LABB_2_dungeon_crawler.Interfaces;
using ITHS_LABB_2_dungeon_crawler.Models;
using ITHS_LABB_2_dungeon_crawler.Rendering;
using LootItem = ITHS_LABB_2_dungeon_crawler.Entities.Loot.Loot;

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
            //var elementAtNewPosition = Elements.SingleOrDefault(e => e.Position.X == newPosition.X && e.Position.Y == newPosition.Y);
            var elementAtNewPosition = ElementAtPosition(newPosition);
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
                case LootItem loot:
                    if (movable is Player player)
                    {
                        loot.Apply(player);
                        elements.Remove(loot);
                        player.Position = newPosition;
                        return true;
                    }
                    return false;
                case Boss:
                    HandleCombat((IFightable)movable, (IFightable)elementAtNewPosition);
                    return true;
                case null:
                    Console.SetCursorPosition(movable.Position.X, movable.Position.Y + LevelElement.levelYOffset);
                    Console.Write(" ");
                    movable.Position = newPosition;
                    return true;
            }

            return false;
        }

        private LevelElement ElementAtPosition(Position position)
        {
            var elementAtPosition = Elements.SingleOrDefault(e => e.Position.X == position.X && e.Position.Y == position.Y);
            return elementAtPosition;
        }

        private void HandleCombat(IFightable attacker, IFightable defender)
        {
            Combat.Fight(attacker, defender);
            HandleEnemyDeath(attacker);
            HandleEnemyDeath(defender);
        }

        private void HandleEnemyDeath(IFightable fighter)
        {
            if (fighter is Enemy enemy && enemy.HP <= 0)
            {
                elements.Remove(enemy);
                DropLoot(enemy.Position);

                var elementAtPosition = ElementAtPosition(enemy.Position);
                if (elementAtPosition is Loot)
                {
                    GameRenderer.LootLog(enemy, (Loot)elementAtPosition);
                }

                Player player = Elements.OfType<Player>().Single();
                player.IncreaseEnemiesSlain();
            }

            if (fighter is Boss boss && boss.HP <= 0)
            {
                elements.Remove(boss);
            }
        }

        private void DropLoot(Position position)
        {
            int loot = Random.Shared.Next(4);

            switch (loot)
            {
                case 0:
                    break;
                case 1:
                    elements.Add(new HealthPotion(position));
                    break;
                case 2:
                    elements.Add(new AttackBuff(position));
                    break;
                case 3:
                    elements.Add(new DefenceBuff(position));
                    break;
            }
        }
    }
}
