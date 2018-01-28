using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public float force = 100f;

	// Use this for initialization
	void Start () {
        StartCoroutine(Cooldown(2));
	}

    private IEnumerator Cooldown(int v) {
        yield return new WaitForSeconds(v);
        GameManager.instance.playing = true;
    }

    // Update is called once per frame
    void Update() {
        if (GameManager.instance.playing) {
            if (Input.GetButtonDown("NextPlanet")) {
                Debug.Log("NextPlanet");
                GameManager.instance.NextPlanet();
            } else if (Input.GetButtonDown("PreviousPlanet")) {
                Debug.Log("Previous");
                GameManager.instance.PreviousPlanet();
            } else if (Input.GetButton("AddForce")) {
                GameManager.instance.currentPlanet.GetComponent<Planet>().AddForce(force);
            }
			if (MicTestManager.instance) {
				float power = MicTestManager.instance.power;
				GameManager.instance.currentPlanet.GetComponent<Planet> ().AddForce (power);
			}
            
        }
		if (Input.GetButtonDown ("Menu")) {
			GameObject.Find ("Menu").GetComponent<MainMenu> ().Toggle ();
		}
	}
}
