namespace SnakeGame
{
    /// <summary>
    /// Struct that keeps the data of highscores
    /// </summary>
    public struct HighScore
    {
        // Properties
        public string Name { get; }
        public float Score { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the user</param>
        /// <param name="score">Score of the user</param>
        public HighScore(string name, float score)
        {
            Name = name;
            Score = score;
        }
    }
}