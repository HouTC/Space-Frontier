using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Boundary is used to limit spaceship's movement to prevent the ship 
 * from goinig beyond screen
 */
[System.Serializable]
public class Boundary
{
    public float left, right, bottom, top;
}

public class PlayerController : MonoBehaviour {
    public float shipSpeed;
    public float shipRotation;
    public Boundary boundary;
    public float shootingRate;
    private float nextShot;
    //shot variable is bullet game object
    public GameObject shot;
    //shotPoint variable is the position of gun muzzle
    public Transform shotPoint;
	
	// Update is called once per frame
	void Update () {
        /*check if the current time exceeds the time 
         *required for the next bullet
         */
        if (Time.time > nextShot)
        {
            nextShot = Time.time + shootingRate;
            Instantiate(shot, shotPoint.position, shotPoint.rotation);
			GetComponent<AudioSource> ().Play ();
        }
    }

    private void FixedUpdate()
    {
        //Record player's input about direction
        float movementHori = Input.GetAxis("Horizontal");
        float movementVerti = Input.GetAxis("Vertical");

        //Move the space ship
        Vector3 movement = new Vector3(movementHori, 0.0f, movementVerti);
        GetComponent<Rigidbody>().velocity = movement * shipSpeed;

        //Let the spaceship tilt a little, when the spacecraft moves left and right 
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(GetComponent<Rigidbody>().velocity.x * -shipRotation + 89.50f, 89.99f, 89.99f);

        //Limit the spacecraft's range of movement
        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.left, boundary.right),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.bottom, boundary.top)
        );
    }
}
