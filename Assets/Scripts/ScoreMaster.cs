using System.Collections;
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
        Debug.Log("----------");
        List<int> frameList = new List<int>();
        int subTotal = 0;
        bool beginingFrame = true;

        foreach(int score in rolls)
        {
            subTotal += score;
            if (beginingFrame == true)
            {
                if (score == 10)
                {
                    frameList.Add(subTotal);
                }
                else
                {
                    beginingFrame = false;
                }
            }
            else
            {
                frameList.Add(subTotal);
                beginingFrame = true;
                subTotal = 0;
            }
        }

        foreach (int score in frameList)
        {
            Debug.Log("Return - " + score);
        }

        return frameList;
    }
}
