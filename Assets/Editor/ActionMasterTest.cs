using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
[Category("Action Testing")]
public class ActionMasterTest
{
 //   private List<int> pinFalls;
 //   private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
 //   private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
 //   private ActionMaster.Action reset = ActionMaster.Action.Reset;
 //   private ActionMaster.Action endGame = ActionMaster.Action.EndGame;

 //   [SetUp]
 //   public void Setup()
 //   {
 //       pinFalls = new List<int>();
 //   }

 //   [Test]
	//public void T00_PassingTest() {
 //       Assert.AreEqual(1, 1);
	//}

 //   [Test]
 //   public void T01_OneStrikeReturnsEndTurn()
 //   {
 //       pinFalls.Add(10);
 //       Assert.AreEqual(expected: endTurn, actual: ActionMaster.NextAction(pinFalls));
 //   }

 //   [Test]
 //   public void T02_Bowl8ReturnsTidy()
 //   {
 //       pinFalls.Add(8);
 //       Assert.AreEqual(expected: tidy, actual: ActionMaster.NextAction(pinFalls));
 //   }

 //   [Test]
 //   public void T03_Bowl28SpareReturnsEndTurn()
 //   {
 //       pinFalls = new List<int>() {
 //           2, 8  //  1st frame
 //       };

 //       Assert.AreEqual(expected: endTurn, actual: ActionMaster.NextAction(pinFalls));
 //   }

 //   [Test]
 //   public void T04_Bowl4And2ReturnsEndTurn()
 //   {
 //       pinFalls = new List<int>() {
 //           4, 2  //  1st frame
 //       };

 //       Assert.AreEqual(expected: endTurn, actual: ActionMaster.NextAction(pinFalls));
 //   }

 //   [Test]
 //   public void T05_CheckResetAtStrikeInLastFrame()
 //   {
 //       pinFalls = new List<int>() {
 //           1, 1, //  1st frame
 //           1, 1, //  2nd frame
 //           1, 1, //  3rd frame
 //           1, 1, //  4th frame
 //           1, 1, //  5th frame
 //           1, 1, //  6th frame
 //           1, 1, //  7th frame
 //           1, 1, //  8th frame
 //           1, 1, //  9th frame
 //           10    // 10th frame
 //       };

 //       Assert.AreEqual(expected: reset, actual: ActionMaster.NextAction(pinFalls));
 //   }

 //   [Test]
 //   public void T06_CheckResetAtSpareInLastFrame()
 //   {
 //       pinFalls = new List<int>() {
 //           1, 1, //  1st frame
 //           1, 1, //  2nd frame
 //           1, 1, //  3rd frame
 //           1, 1, //  4th frame
 //           1, 1, //  5th frame
 //           1, 1, //  6th frame
 //           1, 1, //  7th frame
 //           1, 1, //  8th frame
 //           1, 1, //  9th frame
 //           1, 9  // 10th frame
 //       };

 //       Assert.AreEqual(expected: reset, actual: ActionMaster.NextAction(pinFalls));
 //   }

 //   [Test]
 //   public void T07_YouTubeRollsEndInEndGame()
 //   {
 //       pinFalls = new List<int>() {
 //           8,2, //  1st frame
 //           7,3, //  2nd frame
 //           3,4, //  3rd frame
 //           10,  //  4th frame
 //           2,8, //  5th frame
 //           10,  //  6th frame
 //           10,  //  7th frame
 //           8,0, //  8th frame
 //           10,  //  9th frame
 //           8,2, // 10th frame
 //           9    // Spcl frame
 //       };

 //       Assert.AreEqual(expected: endGame, actual: ActionMaster.NextAction(pinFalls));
 //   }

 //   [Test]
 //   public void T08_GameEndsAtBowl20()
 //   {
 //       pinFalls = new List<int>() {
 //           1, 1, //  1st frame
 //           1, 1, //  2nd frame
 //           1, 1, //  3rd frame
 //           1, 1, //  4th frame
 //           1, 1, //  5th frame
 //           1, 1, //  6th frame
 //           1, 1, //  7th frame
 //           1, 1, //  8th frame
 //           1, 1, //  9th frame
 //           1, 1  // 10th frame
 //       };

 //       Assert.AreEqual(expected: endGame, actual: ActionMaster.NextAction(pinFalls));
 //   }

 //   [Test]
 //   public void T09_DarylBowl20()
 //   {
 //       pinFalls = new List<int>() {
 //           1, 1, //  1st frame
 //           1, 1, //  2nd frame
 //           1, 1, //  3rd frame
 //           1, 1, //  4th frame
 //           1, 1, //  5th frame
 //           1, 1, //  6th frame
 //           1, 1, //  7th frame
 //           1, 1, //  8th frame
 //           1, 1, //  9th frame
 //           10, 5 // 10th frame
 //       };

 //       Assert.AreEqual(expected: tidy, actual: ActionMaster.NextAction(pinFalls));
 //   }

 //   [Test]
 //   public void T10_BensBowl20Test()
 //   {
 //       pinFalls = new List<int>() {
 //           1, 1, //  1st frame
 //           1, 1, //  2nd frame
 //           1, 1, //  3rd frame
 //           1, 1, //  4th frame
 //           1, 1, //  5th frame
 //           1, 1, //  6th frame
 //           1, 1, //  7th frame
 //           1, 1, //  8th frame
 //           1, 1, //  9th frame
 //           10, 0 // 10th frame
 //       };

 //       Assert.AreEqual(expected: tidy, actual: ActionMaster.NextAction(pinFalls));
 //   }

 //   [Test]
 //   public void T11_TwoStrikesLastFrame()
 //   {
 //       pinFalls = new List<int>() {
 //           1, 1,  //  1st frame
 //           1, 1,  //  2nd frame
 //           1, 1,  //  3rd frame
 //           1, 1,  //  4th frame
 //           1, 1,  //  5th frame
 //           1, 1,  //  6th frame
 //           1, 1,  //  7th frame
 //           1, 1,  //  8th frame
 //           1, 1,  //  9th frame
 //           10, 10 // 10th frame
 //       };

 //       Assert.AreEqual(expected: reset, actual: ActionMaster.NextAction(pinFalls));
 //   }

 //   [Test]
 //   public void T12_NathanBowlIndexTest()
 //   {
 //       pinFalls = new List<int>() {
 //           0, 10, //  1st frame
 //           5, 1   //  2nd frame
 //       };

 //       Assert.AreEqual(expected: endTurn, actual: ActionMaster.NextAction(pinFalls));
 //   }

 //   [Test]
 //   public void T13_Dondi10thFrameTurkey()
 //   {
 //       pinFalls = new List<int>() {
 //           1, 1, //  1st frame
 //           1, 1, //  2nd frame
 //           1, 1, //  3rd frame
 //           1, 1, //  4th frame
 //           1, 1, //  5th frame
 //           1, 1, //  6th frame
 //           1, 1, //  7th frame
 //           1, 1, //  8th frame
 //           1, 1, //  9th frame
 //           10    // 10th frame
 //       };

 //       Assert.AreEqual(expected: reset, actual: ActionMaster.NextAction(pinFalls));

 //       pinFalls.Add(10);
 //       Assert.AreEqual(expected: reset, actual: ActionMaster.NextAction(pinFalls));

 //       pinFalls.Add(10);
 //       Assert.AreEqual(expected: endGame, actual: ActionMaster.NextAction(pinFalls));
 //   }

 //   [Test]
 //   public void T14_ZeroOneGivesEndTurn()
 //   {
 //       pinFalls = new List<int>() { 0, 1 };
 //       Assert.AreEqual(expected: endTurn, actual: ActionMaster.NextAction(pinFalls));
 //   }
}
