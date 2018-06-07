using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

[TestFixture]
public class ButtonTests : MonoBehaviour
{
    [Test]
    public void Button_Click_ValueEqual()
    {
        GameController gameController;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        Assert.AreEqual(1, gameController.tScale);
    }

}
