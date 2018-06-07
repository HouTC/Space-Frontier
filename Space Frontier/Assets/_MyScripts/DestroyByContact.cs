using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    private GameController gameController;
    private HealthLevel healthLevel;
	public int scoreValue;

    //Use this for initialization
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    //This method is used to check whether collision happen
    void OnTriggerEnter(Collider other)
    {
        //Generate explosion effect of asteroid when collision happen
        Instantiate(explosion, transform.position, transform.rotation);

        //If asteroid collide with player's ship
        if (other.tag == "Player")
        {
            //Generate explosion effect of player's ship
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(gameObject);

            GameObject playerObject = GameObject.FindWithTag("Player");
            if (playerObject != null)
            {
                healthLevel = playerObject.GetComponent<HealthLevel>();
            }

            if (playerObject == null)
            {
                Debug.Log("Cannot find 'HealthLevel' script");
            }

            //player's ship take damage of 5
            healthLevel.TakeDamage(5);
            healthLevel.UpdateHealth();

            //end the game and destroy player's ship when health is below 0
            if (healthLevel.currentHealth <= 0)
            {
				other.gameObject.GetComponent<PlayerController> ().alive = false; //Buttons to show up, restart and mainmenu
                Destroy(other.gameObject);
                gameController.GameOver();
				Time.timeScale = 0; //The asteroids will stop spawning
            }
        }

        //If asteroid collide with player's bullets
        else
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
		
		gameController.AddScore(scoreValue);//Adds score once object is hit
    }
}
