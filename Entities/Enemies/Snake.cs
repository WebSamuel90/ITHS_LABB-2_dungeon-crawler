using ITHS_LABB_2_dungeon_crawler.Models;

namespace ITHS_LABB_2_dungeon_crawler.Entities.Enemies
{
    public class Snake(Position Position) : Enemy(Position, 's', ConsoleColor.DarkRed, "Snake", 25, new Dice(3, 4, 2), new Dice(1, 8, 5))
    {
        public override Position Update(Position playerPosition)
        {
            double distance = GetDistanceBetween(this.Position, playerPosition);

            double longestDistance = distance;
            Position bestPosition = this.Position;

            if (distance <= 2)
            {
                for (int i = 0; i < 4; i++)
                {
                    Position newPosition = new(Position.X, Position.Y);
                    switch (i)
                    {
                        case 0:
                            newPosition.Y--;
                            break;
                        case 1:
                            newPosition.Y++;
                            break;
                        case 2:
                            newPosition.X--;
                            break;
                        case 3:
                            newPosition.X++;
                            break;
                    }

                    double newDistance = GetDistanceBetween(newPosition, playerPosition);

                    if (newDistance > longestDistance)
                    {
                        longestDistance = newDistance;
                        bestPosition = newPosition;
                    }
                }
            }

            return bestPosition;
        }
    }
}
