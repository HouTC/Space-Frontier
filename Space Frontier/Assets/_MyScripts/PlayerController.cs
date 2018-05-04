using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Limit the spaceship's position
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
    public GameObject shot;
    public Transform shotPoint;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextShot)
        {
            nextShot = Time.time + shootingRate;
            Instantiate(shot, shotPoint.position, shotPoint.rotation);
			GetComponent<AudioSource> ().Play ();
        }

    }

    private void FixedUpdate()
    {
        float movementHori = Input.GetAxis("Horizontal");
        float movementVerti = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(movementHori, 0.0f, movementVerti);
        GetComponent<Rigidbody>().velocity = movement * shipSpeed;

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(GetComponent<Rigidbody>().velocity.x * -shipRotation + 89.50f, 89.99f, 89.99f);

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.left, boundary.right),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.bottom, boundary.top)
        );
    }
}
