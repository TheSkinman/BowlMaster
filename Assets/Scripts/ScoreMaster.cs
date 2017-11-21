﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {

    // Returns a list of cumulative scores, like a score card.
    public static List<int> ScoreCumulative(List<int> rolls)
    {
        List<int> cumulativeScore = new List<int>();
        int runningTotal = 0;

        foreach(int frameScore in ScoreFrames(rolls))
        {
            runningTotal += frameScore;
            cumulativeScore.Add(runningTotal);
        }

        return cumulativeScore;
    }

    // Return a list of individual frame scores, NOT cumulative.
    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frames = new List<int>();

        for (int i = 1; i < rolls.Count; i += 2)
        {
            if (frames.Count == 10) { break; }          // Prevent 11th frame score

            if ((rolls[i - 1] + rolls[i]) < 10)         // Normal "open" frame
            {
                frames.Add(rolls[i - 1] + rolls[i]);
            }

            if (rolls.Count - i <= 1) { break; }        // Insufficient look-ahead

            if (rolls[i - 1] == 10)                     // STRIKE
            {
                i--;
                frames.Add(10 + rolls[i + 1] + rolls[i + 2]);
            }
            else if ((rolls[i - 1] + rolls[i]) == 10)        // SPARE
            {
                frames.Add(10 + rolls[i + 1]);
            }
        }

        return frames;
    }
}
