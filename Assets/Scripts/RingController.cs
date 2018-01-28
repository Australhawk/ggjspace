using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour {
    public Planet planet;
	private Animator animator;
    bool active;
    bool finished;

	// Use this for initialization
	void Start () {
		animator = transform.GetChild (0).GetComponent<Animator> ();
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
		this.animator.SetBool ("PlanetOnPosition", true);
        GameManager.instance.NextPlanet();
        this.GetComponent<Renderer>().material.color = Color.green;
        FindObjectOfType<RingManager>().RingFinished(this);
    }
	private Animator GetAnimator(){
		
	}
    public void PlanetEntered (Planet planet) {
        if (this.planet.Equals(planet)) {
            Debug.Log("Planet entered!");
			this.animator.SetBool ("PlanetNear", true);
            this.GetComponent<Renderer>().material.color = Color.yellow;
            active = true;
        }
     }

    internal void PlanetExited(Planet planet) {
        if (this.planet.Equals(planet)) {
			this.animator.SetBool ("PlanetNear", false);
            this.GetComponent<Renderer>().material.color = Color.white;
            active = false;
        }
    }
}