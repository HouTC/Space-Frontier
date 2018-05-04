using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ButtonPause(){
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
		} else if (Time.timeScale == 1) {
			Time.timeScale = 0;

		}
}
}