using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour {
    Planet currentPlanet;
    RingController currentRing;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdatePlanet();
        this.transform.LookAt(currentRing.transform);
        this.transform.position = currentPlanet.transform.position+Vector3.up*3;
	}

    private void UpdatePlanet() {
        currentPlanet = GameManager.instance.currentPlanet.GetComponent<Planet>();
        List<RingController> rings = GameManager.instance.GetComponent<RingManager>().rings;
        foreach(RingController ring in rings) {
            if (ring.planet.Equals(currentPlanet)) {
                currentRing = ring;
                break;
            }
        }
    }
}
