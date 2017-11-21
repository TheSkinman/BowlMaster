using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
[Category("Score Testing")]
public class ScoreMasterTest {
    private List<int> pinFalls;
    private List<int> frames;

    [Test]
	public void T00_PassingTest () {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T0_1Bowl23 () {
		pinFalls = new List<int>() {
            2, 3 //  1st frame
        };
        frames = new List<int>() {
            5  // 1st frame
        };
        Assert.AreEqual (frames, ScoreMaster.ScoreFrames (pinFalls));
	}

    [Test]
    public void T02_Bowl234()
    {
        pinFalls = new List<int>() {
            2, 3, // 1st frame
            4     // 2nd frame
        };
        frames = new List<int>() {
            5  // 1st frame
        };
        Assert.AreEqual(frames, ScoreMaster.ScoreFrames(pinFalls));
    }

    [Test]
    public void T03_Bowl2345()
    {
        pinFalls = new List<int>() {
            2, 3, // 1st frame
            4, 5  // 2nd frame
        };
        frames = new List<int>() {
            5, // 1st frame
            9  // 2nd frame
        };
        Assert.AreEqual(frames, ScoreMaster.ScoreFrames(pinFalls));
    }

    [Test]
    public void T04_Bowl23456()
    {
        pinFalls = new List<int>() {
            2, 3, // 1st frame
            4, 5, // 2nd frame
            6     // 3rd frame
        };
        frames = new List<int>() {
            5, // 1st frame
            9  // 2nd frame
        };
        Assert.AreEqual(frames, ScoreMaster.ScoreFrames(pinFalls));
    }

    [Test]
    public void T05_Bowl234561()
    {
        pinFalls = new List<int>() {
            2, 3, // 1st frame
            4, 5, // 2nd frame
            6, 1  // 3rd frame
        };
        frames = new List<int>() {
            5, // 1st frame
            9, // 2nd frame
            7  // 3rd frame
        };
        Assert.AreEqual(frames, ScoreMaster.ScoreFrames(pinFalls));
    }

    [Test]
    public void T06_Bowl2345612()
    {
        pinFalls = new List<int>() {
            2, 3, // 1st frame
            4, 5, // 2nd frame
            6, 1, // 3rd frame
            2     // 4th frame
        };
        frames = new List<int>() {
            5, // 1st frame
            9, // 2nd frame
            7  // 3rd frame
        };
        Assert.AreEqual(frames, ScoreMaster.ScoreFrames(pinFalls));
    }

    [Test]
    public void T07_BowlX1()
    {
        pinFalls = new List<int>() {
            10, 1 // 1st frame
        };
        frames = new List<int>() {
        };
        Assert.AreEqual(frames, ScoreMaster.ScoreFrames(pinFalls));
    }

    [Test]
    public void T08_Bowl19()
    {
        pinFalls = new List<int>() {
            1, 9 // 1st frame
        };
        frames = new List<int>() { };
        Assert.AreEqual(frames, ScoreMaster.ScoreFrames(pinFalls));
    }

    [Test]
    public void T09Bowl123455()
    {
        pinFalls = new List<int>() {
            1, 2, // 1st frame
            3, 4, // 2nd frame
            5, 5  // 3rd frame
        };
        frames = new List<int>() {
            3, // 1st frame
            7  // 2nd frame
        };
        Assert.AreEqual(frames, ScoreMaster.ScoreFrames(pinFalls));
    }

    [Test]
    public void T10SpareBonus()
    {
        pinFalls = new List<int>() {
            1, 2, // 1st frame
            3, 5, // 2nd frame
            5, 5, // 3rd frame
            3, 3  // 4th frame
        };
        frames = new List<int>() {
            3,  // 1st frame
            8,  // 2nd frame
            13, // 3rd frame
            6   // 4th frame
        };
        Assert.AreEqual(frames, ScoreMaster.ScoreFrames(pinFalls));
    }

    [Test]
    public void T11SpareBonus2()
    {
        pinFalls = new List<int>() {
                1, 2, // 1st frame
                3, 5, // 2nd frame
                5, 5, // 3rd frame
                3, 3, // 4th frame
                7, 1, // 5nd frame
                9, 1, // 6rd frame
                6     // 7th frame
        };
        frames = new List<int>() {
                3,  // 1st frame
                8,  // 2nd frame
                13, // 3rd frame
                6,  // 4th frame
                8,  // 5th frame
                16  // 6th frame
        };
        Assert.AreEqual(frames, ScoreMaster.ScoreFrames(pinFalls));
    }

    [Test]
    public void T12StrikeBonus()
    {
        pinFalls = new List<int>() {
                10,   // 1st frame
                3, 4  // 2nd frame
        };
        frames = new List<int>() {
                17,  // 1st frame
                7    // 2nd frame
        };
        Assert.AreEqual(frames, ScoreMaster.ScoreFrames(pinFalls));
    }

    [Test]
    public void T13StrikeBonus3()
    {
        pinFalls = new List<int>() {
                1,  2, // 1st frame
                3,  4, // 2nd frame
                5,  4, // 3rd frame
                3,  2, // 4th frame
                10,    // 5nd frame
                1, 3,  // 6nd frame
                3, 4  // 7rd frame
        };
        frames = new List<int>() {
                3,  // 1st frame
                7,  // 2nd frame
                9,  // 3rd frame
                5,  // 4th frame
                14, // 5nd frame
                4,  // 6rd frame
                7   // 7th frame
        };
        Assert.AreEqual(frames, ScoreMaster.ScoreFrames(pinFalls));
    }

    [Test]
    public void T14MultiStrikes()
    {
        int[] rolls = { 10, 10, 2, 3 };
        int[] frames = { 22, 15, 5 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T15MultiStrikes3()
    {
        int[] rolls = { 10, 10, 2, 3, 10, 5, 3 };
        int[] frames = { 22, 15, 5, 18, 8 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T16TestGutterGame()
    {
        int[] rolls = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] totalS = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));
    }

    [Test]
    public void T17TestAllOnes()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        int[] totalS = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
        Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));
    }

    [Test]
    public void T18TestAllStrikes()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
        int[] totalS = { 30, 60, 90, 120, 150, 180, 210, 240, 270, 300 };
        Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));
    }

    [Test]
    public void T19TestImmediateStrikeBonus()
    {
        int[] rolls = { 5, 5, 3 };
        int[] frames = { 13 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T20SpareInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9, 7 };
        int[] totalS = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 35 };
        Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));
    }

    [Test]
    public void T21StrikeInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 2, 3 };
        int[] totalS = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 33 };
        Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));
    }

    //http://slocums.homestead.com/gamescore.html
    [Category("Verification")]
    [Test]
    public void TG02GoldenCopyA()
    {
        int[] rolls = { 10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 10, 8, 1 };
        int[] totalS = { 20, 39, 48, 66, 74, 84, 90, 120, 148, 167 };
        Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));
    }

    //http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
    [Category("Verification")]
    [Test]
    public void TG03GoldenCopyB1of3()
    {
        int[] rolls = { 10, 9, 1, 9, 1, 9, 1, 9, 1, 7, 0, 9, 0, 10, 8, 2, 8, 2, 10 };
        int[] totalS = { 20, 39, 58, 77, 94, 101, 110, 130, 148, 168 };
        Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));
    }

    //http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
    [Category("Verification")]
    [Test]
    public void TG03GoldenCopyB2of3()
    {
        int[] rolls = { 8, 2, 8, 1, 9, 1, 7, 1, 8, 2, 9, 1, 9, 1, 10, 10, 7, 1 };
        int[] totalS = { 18, 27, 44, 52, 71, 90, 110, 137, 155, 163 };
        Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));
    }

    //http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
    [Category("Verification")]
    [Test]
    public void TG03GoldenCopyB3of3()
    {
        int[] rolls = { 10, 10, 9, 0, 10, 7, 3, 10, 8, 1, 6, 3, 6, 2, 9, 1, 10 };
        int[] totalS = { 29, 48, 57, 77, 97, 116, 125, 134, 142, 162 };
        Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));
    }

    // http://brownswick.com/wp-content/uploads/2012/06/OpenBowlingScores-6-12-12.jpg
    [Category("Verification")]
    [Test]
    public void TG03GoldenCopyC1of3()
    {
        int[] rolls = { 7, 2, 10, 10, 10, 10, 7, 3, 10, 10, 9, 1, 10, 10, 9 };
        int[] totalS = { 9, 39, 69, 96, 116, 136, 165, 185, 205, 234 };
        Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));
    }

    // http://brownswick.com/wp-content/uploads/2012/06/OpenBowlingScores-6-12-12.jpg
    [Category("Verification")]
    [Test]
    public void TG03GoldenCopyC2of3()
    {
        int[] rolls = { 10, 10, 10, 10, 9, 0, 10, 10, 10, 10, 10, 9, 1 };
        int[] totalS = { 30, 60, 89, 108, 117, 147, 177, 207, 236, 256 };
        Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));
    }
}