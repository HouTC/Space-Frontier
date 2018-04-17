using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

    public float existingTime;

    // Use this for initialization
    void Start () {
        Destroy(gameObject, existingTime);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
