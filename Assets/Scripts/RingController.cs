using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour {
    public Planet planet;
	public AudioClip successAudio;
	private Animator animator;
	private AudioSource sfx;
    bool active;
    bool finished;

	// Use this for initialization
	void Start () {
		animator = transform.GetChild (0).GetComponent<Animator> ();
		sfx = this.gameObject.AddComponent<AudioSource> ();
		sfx.loop = false;
	}
	void PaintMaterial(Color color){
		transform.GetChild (0).GetChild (1).GetComponent<Renderer> ().material.color = color;
		transform.GetChild (0).GetChild (2).GetComponent<Renderer> ().material.color = color;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.planet) {
            float diameter = this.planet.planetObject.planetRadius * 4;
            this.transform.localScale = new Vector3(diameter, diameter, diameter);
            transform.LookAt(this.planet.transform);
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
		sfx.clip = successAudio;
		sfx.time = 0.4f;
		sfx.Play ();
		this.animator.SetBool ("PlanetOnPosition", true);
        GameManager.instance.NextPlanet();
		this.PaintMaterial(Color.green);
        FindObjectOfType<RingManager>().RingFinished(this);
    }
	public void PlanetEntered (Planet planet) {
        if (this.planet.Equals(planet)) {
            Debug.Log("Planet entered!");
			this.animator.SetBool ("PlanetNear", true);
			this.PaintMaterial(Color.yellow);
            active = true;
        }
    }
    internal void PlanetExited(Planet planet) {
        if (this.planet.Equals(planet)) {
			this.animator.SetBool ("PlanetNear", false);
			this.PaintMaterial(Color.white);
            active = false;
        }
    }
}