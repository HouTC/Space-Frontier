using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject asteroid;
    public Vector3 asteroidPosition;

    //It is used to set the preparation time to start generating obstacles
    public float startWait;

    //It is used to set the interval for each obstacle to be generated
    public float asteroidWait;

    public Text gameOverText;
    public bool gameOver = false;

    void Start()
    {
        StartCoroutine(Waves());
        gameOver = false;
        gameOverText.text = "";
    }

    IEnumerator Waves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            
                //It is used to record where the asteroid was generated
                Vector3 randomAsteroidPosition = new Vector3(Random.Range(-asteroidPosition.x, asteroidPosition.x), asteroidPosition.y, asteroidPosition.z);

                Quaternion asteroidRotation = Quaternion.identity;
                Instantiate(asteroid, randomAsteroidPosition, asteroidRotation);
                yield return new WaitForSeconds(asteroidWait);

        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game over!";
        gameOver = true;
    }
}