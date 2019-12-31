namespace SnakeGame
{
    public struct HighScore
    {
        public string Name { get; }
        public float Score { get; }

        public HighScore(string name, float score)
        {
            Name = name;
            Score = score;
        }
    }
}