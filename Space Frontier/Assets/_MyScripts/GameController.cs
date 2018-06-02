using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject asteroid = null;
    //asteroidPosition is used to set the position where the obstacle was generated
    public Vector3 asteroidPosition;
    //startWait is used to set the preparation time to start generating obstacles
    public float startWait;
    //asteroidWait is used to set the interval for each obstacle to be generated
    public float asteroidWait;
    public Text gameOverText;
    //gameOver variable is the boolean flag to determine if the game is over
    public bool gameOver = false;

    GameObject[] pauseObjects;
    GameObject[] finishObjects;
    PlayerController playerController;

    void Start()
    {
        StartCoroutine (Waves ());

        //No text should appear at the beginning of the game
        gameOverText.text = "";

        Time.timeScale = 1;

        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");            //gets all objects with tag ShowOnPause
        finishObjects = GameObject.FindGameObjectsWithTag("ShowOnFinish");          //gets all objects with tag ShowOnFinish

        hidePaused();
        hideFinished();

        //Checks to make sure MainLevel is the loaded level
        if(Application.loadedLevelName == "Main")
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        //uses the p button to pause and unpause the game
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale == 1 && playerController.alive == true)
            {
                Time.timeScale = 0;
                showPaused();
            } else if (Time.timeScale == 0 && playerController.alive == true)
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }

        //shows finish gameobjects if player is dead and timescale = 0
        if (Time.timeScale == 0 && playerController.alive == false)
        {
            showFinished();
        }
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

    public void ButtonPause ()
    {
        if(Time.timeScale == 1 && playerController.alive == true)
        {
            Time.timeScale = 0;
            showPaused();
        } else if (Time.timeScale == 0 && playerController.alive == true)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    public void GameOver()
    {
        //Set the game over text as "Game over!" when game is over
        gameOverText.text = "Game Over!";
        gameOver = true;
        gameObject.SetActive(true);
    }

    //Reloads the Level
    public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    //controls the pausing of the scene
    public void pauseControl()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        } else if (Time.timeScale == 0){
            Time.timeScale = 1;
            hidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach(GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach(GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    //shows objects with ShowOnFinish tag
    public void showFinished()
    {
        foreach(GameObject g in finishObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnFinish tag
    public void hideFinished()
    {
        foreach(GameObject g in finishObjects)
        {
            g.SetActive(false);
        }
    }

    //loads inputted level
    public void LoadLevel(string level)
    {
        Application.LoadLevel(level);
    }
}