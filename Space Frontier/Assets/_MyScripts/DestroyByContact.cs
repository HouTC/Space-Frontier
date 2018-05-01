using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    private GameController gameController;


    // Use this for initialization
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

    }

    void OnTriggerEnter(Collider other)
    {
        Instantiate(explosion, transform.position, transform.rotation);

        Destroy(other.gameObject);
        Destroy(gameObject);

        if (other.tag == "Player")
        {
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
