using System.Collections.Generic;

namespace SnakeGame
{
    /// <summary>
    /// This class manages the comparison from a score to another
    /// </summary>
    public class HighscoreComparer : IComparer<HighScore>
    {
        /// <summary>
        /// Compare a score with another
        /// </summary>
        /// <param name="hsc1">One score</param>
        /// <param name="hsc2">Another score</param>
        /// <returns>Depending if its lower, higher or equal</returns>
        public int Compare(HighScore hsc1, HighScore hsc2)
        {
            return hsc1.Score.CompareTo(hsc2.Score);
        }
    }
}
