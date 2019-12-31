﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SnakeGame
{
    public class HighscoreComparer : IComparer<HighScore>
    {
        public int Compare(HighScore hsc1, HighScore hsc2)
        {
            return hsc1.Score.CompareTo(hsc2.Score);
        }
    }
}