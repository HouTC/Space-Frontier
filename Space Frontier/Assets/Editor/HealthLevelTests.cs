using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

[TestFixture]
public class HealthLevelTests {

    //Test if the health level of the ship after damge is equal to expected value
    [Test]
    public void Damage_Attacked_HealthEqual()
    {
        HealthLevel health = new HealthLevel();
        health.currentHealth = 10;

        health.TakeDamage(5);

        Assert.AreEqual(5f, health.currentHealth);

    }

    [Test]
	public void HealthLevelTestsSimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator HealthLevelTestsWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}
}



