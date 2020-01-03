using System;
using System.Collections.Generic;
using System.IO;

namespace SnakeGame
{
    /// <summary>
    /// Manages the Highscore of the user
    /// </summary>
    public class HighScoreControl
    {
        // Instance variables
        private string fileName;
        private char separator;
        private List<HighScore> scoreList;

        /// <summary>
        /// Constructor
        /// </summary>
        public HighScoreControl()
        {
            fileName = $"HighScores.txt";
            separator = '\t';
            scoreList = new List<HighScore>();
        }

        /// <summary>
        /// Creates the file HighScores
        /// </summary>
        public void CreateHighScores()
        {
            if (!File.Exists(fileName))
            {
                using (StreamWriter sw = File.CreateText(fileName))
                {
                }
            }

            StreamReader sr = new StreamReader(fileName);
            char separator = '\t';
            string s;

            while ((s = sr.ReadLine()) != null)
            {
                string[] nameAndScore = s.Split(separator);
                string name = nameAndScore[0];
                float score = Convert.ToSingle(nameAndScore[1]);
                scoreList.Add(new HighScore(name, score));
            }
            sr.Close();
        }

        /// <summary>
        /// Add score to the file and list
        /// </summary>
        /// <param name="mc"></param>
        public void AddScore(MainControl mc)
        {
            // Local variable
            string name;

            // If number of recorded scores is less than 8, saves the new score
            if (scoreList.Count < 8)
            {
                Console.Clear();
                Console.WriteLine("New HighScore! What's your name?\n");
                name = Console.ReadLine() + "          ";
                name = name.Substring(0, 10);

                Console.WriteLine($"\nYour score was " +
                    "added to the HighScores!\n");

                scoreList.Add(new HighScore(name, mc.Score));
                SortHighScores();
            }
            // Else remove the lowest score recorded
            else
            {
                bool isHigher = false;
                for (int i = 0; i < scoreList.Count; i++)
                {
                    if (mc.Score > scoreList[i].Score)
                    {
                        isHigher = true;
                    }
                }

                if (isHigher)
                {
                    Console.Clear();
                    Console.WriteLine(
                        "New HighScore! What should we call you?\n");
                    name = Console.ReadLine() + "          ";
                    name = name.Substring(0, 10);

                    Console.WriteLine($"\nYour score of {mc.Score} was " +
                        "added to HighScores!\n");

                    scoreList.Add(new HighScore(name, mc.Score));

                }
            }
        }

        /// <summary>
        /// Organize the scores
        /// </summary>
        public void SortHighScores()
        {
            // Sorts HighScores With The Given Comparer
            scoreList.Sort(new HighscoreComparer());

            //If A Score Was Added, Remove The Lowest Score
            if (scoreList.Count > 8)
            {
                scoreList.RemoveAt(0);
            }
        }

        /// <summary>
        /// Saves the score
        /// </summary>
        public void SaveHighScores()
        {
            StreamWriter sw = new StreamWriter(fileName);

            foreach (HighScore hs in scoreList)
            {
                sw.WriteLine(hs.Name + separator + hs.Score);
            }
            sw.Close();
        }

        /// <summary>
        /// Calls, per order, the Highscore methods
        /// </summary>
        /// <param name="mc">MainControl reference</param>
        public void HighScoreController(MainControl mc)
        {
            AddScore(mc);
            SortHighScores();
            SaveHighScores();
        }
    }
}