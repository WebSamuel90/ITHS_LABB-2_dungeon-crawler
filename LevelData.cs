namespace ITHS_LABB_2_dungeon_crawler
{
    public class LevelData
    {
        private readonly List<LevelElement> elements = [];
        public IEnumerable<LevelElement> Elements => elements;

        public int PlayerStartXPosition { get; set; }
        public int PlayerStartYPositiion { get; set; }

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
                    switch (entityChar)
                    {
                        case '#':
                            elements.Add(new Wall(x, y));
                            break;
                        case '@':
                            PlayerStartXPosition = x;
                            PlayerStartYPositiion = y;
                            break;
                        case 'r':
                            elements.Add(new Rat(x, y));
                            break;
                        case 's':
                            elements.Add(new Snake(x, y));
                            break;
                        default:
                            continue;
                    }
                }
            }
        }
    }
}
