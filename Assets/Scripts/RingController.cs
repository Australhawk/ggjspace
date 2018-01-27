using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour {
    public Planet planet;

    bool active;
    bool finished;

	// Use this for initialization
	void Start () {
		 
	}
	
	// Update is called once per frame
	void Update () {
        if (this.planet) {
            float diameter = this.planet.planetObject.planetRadius * 4;
            this.transform.localScale = new Vector3(diameter, diameter, diameter);
        }
        if (active) {
            float distance = Vector3.Distance(this.transform.position, planet.transform.position);
            if (distance < planet.planetObject.planetRadius) {
                FinishPlanet();
            }
        }
    }

    private void FinishPlanet() {
        finished = true;
        planet.Finished = true;
        active = false;
        GameManager.instance.NextPlanet();
        this.GetComponent<Renderer>().material.color = Color.green;
    }

    public void PlanetEntered (Planet planet) {
        if (this.planet.Equals(planet)) {
            Debug.Log("Planet entered!");
            this.GetComponent<Renderer>().material.color = Color.yellow;
            active = true;
        }
     }

    internal void PlanetExited(Planet planet) {
        if (this.planet.Equals(planet)) {
            float planetRadius = planet.planetObject.planetRadius;
            this.GetComponent<Renderer>().material.color = Color.white;
            active = false;
        }
    }
}