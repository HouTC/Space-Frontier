using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

[TestFixture]
public class HealthLevelTests {

    //Test if the health level of the ship after damge is equal to expected value
    [Test]
    public void TakeDamage_Attacked_HealthEqual()
    {
        HealthLevel health = new HealthLevel();
        health.currentHealth = 5;

        health.TakeDamage(5);

        Assert.AreEqual(0, health.currentHealth);

    }
}



