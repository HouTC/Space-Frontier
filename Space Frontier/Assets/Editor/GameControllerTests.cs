using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

[TestFixture]
public class GameControllerTests : MonoBehaviour {

    [Test]
    public void GameOver_Over_TextEqual()
    {
        GameController gameController = null;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();

        gameController.GameOver();

        Assert.AreEqual("Game Over!", gameController.gameOverText.text);
    }

    [Test]
    public void GameOver_Over_OverTrue()
    {
        //Arrange
        GameController gameController = null;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();

        //Act
        gameController.GameOver();

        //Assert
        Assert.IsTrue(gameController.gameOver);

    }

    [Test]
    public void GameOver_NotOver_OverFalse()
    {
        GameController gameController = null;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();

        Assert.IsFalse(gameController.gameOver);
    }
}
