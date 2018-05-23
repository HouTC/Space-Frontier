using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject asteroid;
    //asteroidPosition is used to set the position where the obstacle was generated
    public Vector3 asteroidPosition;
    //startWait is used to set the preparation time to start generating obstacles
    public float startWait;
    //asteroidWait is used to set the interval for each obstacle to be generated
    public float asteroidWait;
    public Text gameOverText;
    //gameOver variable is the boolean flag to determine if the game is over
    public bool gameOver = false;

    void Start()
    {
        StartCoroutine(Waves());
        //No text should appear at the beginning of the game
        gameOverText.text = "";
    }

    IEnumerator Waves()
    {
        //set the preparation time to start generating obstacles
        yield return new WaitForSeconds(startWait);
        //Generate infinite waves of enemies
        while (true)
        {           
                Vector3 randomAsteroidPosition = new Vector3(Random.Range(-asteroidPosition.x, asteroidPosition.x), asteroidPosition.y, asteroidPosition.z);
                Quaternion asteroidRotation = Quaternion.identity;
                //Generate asteroid objects
                Instantiate(asteroid, randomAsteroidPosition, asteroidRotation);
                yield return new WaitForSeconds(asteroidWait);
        }
    }

    public void GameOver()
    {
        //Set the game over text as "Game over!" when game is over
        gameOverText.text = "Game over!";
        gameOver = true;
    }
}