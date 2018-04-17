using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    // Use this for checking and destroying the bullets going beyond the boundary
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
