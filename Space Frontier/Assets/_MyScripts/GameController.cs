using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 asteroidPosition;
    public int hazardCount;

    //It is used to set the preparation time to start generating obstacles
    public float startWait;

    //It is used to set the interval for each obstacle to be generated
    public float spawnWait;
    public float waveWait;

    public Text gameOverText;
    private bool gameOver;

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
            for (int i = 0; i < hazardCount; i++)
            {
                //It is used to record where the obstacle was generated
                Vector3 spawnPosition = new Vector3(Random.Range(-asteroidPosition.x, asteroidPosition.x), asteroidPosition.y, asteroidPosition.z);

                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}