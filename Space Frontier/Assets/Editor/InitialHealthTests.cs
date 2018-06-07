using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

[TestFixture]
public class InitialHealthTests
{

    [Test]
    public void Health_Initial_valueEqual()
    {
        HealthLevel health = new HealthLevel();
        Assert.AreEqual(15, health.currentHealth);

    }
}



