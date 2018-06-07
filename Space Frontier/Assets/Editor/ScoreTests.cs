using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

[TestFixture]
public class ScoreTests : MonoBehaviour
{
    [Test]
    public void Score_Initial_ValueEqual()
    {
        GameController gameController = null;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        Assert.AreEqual(0, gameController.initialScore);
    }

}
