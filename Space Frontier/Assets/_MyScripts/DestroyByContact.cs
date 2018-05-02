using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    private GameController gameController;
    private HealthLevel healthLevel;


    // Use this for initialization
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        Instantiate(explosion, transform.position, transform.rotation);



        if (other.tag == "Player")
        {
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

            healthLevel.TakeDamage(5);
            if (healthLevel.currentHealth <= 0)
            {
                Destroy(other.gameObject);
                gameController.GameOver();
            }
        }

        else
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
