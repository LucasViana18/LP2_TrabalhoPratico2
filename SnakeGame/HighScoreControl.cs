using System;
using System.Collections.Generic;
using System.IO;

namespace SnakeGame
{
    public class HighScoreControl
    {
        //MainControl mc;
        private string fileName;
        private char separator;
        private List<HighScore> scoreList;

        public HighScoreControl()
        {

            fileName = $"HighScores.txt";
            separator = '\t';
            scoreList = new List<HighScore>();
        }

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

        public void AddScore(MainControl mc)
        {
            string name;

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

        public void SaveHighScores()
        {
            StreamWriter sw = new StreamWriter(fileName);

            foreach (HighScore hs in scoreList)
            {
                sw.WriteLine(hs.Name + separator + hs.Score);
            }
            sw.Close();
        }

        public void HighScoreController(MainControl mc)
        {
            AddScore(mc);
            SortHighScores();
            SaveHighScores();
        }
    }
}