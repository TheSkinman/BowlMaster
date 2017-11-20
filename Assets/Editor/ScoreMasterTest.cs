using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

[TestFixture]
[Category("Score Testing")]
public class ScoreMasterTest {

	[Test]
	public void T01_ScoreMasterTestSimplePasses() {
        // Use the Assert class to test conditions.
        Assert.AreEqual(1, 1);
	}

}
