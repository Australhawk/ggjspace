using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	[HideInInspector]
	public bool playing = false;
	[HideInInspector]
	public string currentMicrophoneDevice;
	public static GameManager instance;
	public GameObject currentPlanet;

	[HideInInspector]
	public GameObject[] planets;
	private int planetIndex = 0;
    internal int level;

    // Use this for initialization
    void Awake () {

		// Create GameManager Instance or destroy if another one exists
		if (instance != null) {
			Destroy (this.gameObject);
		}else{
			instance = this;

			DontDestroyOnLoad (this);
		}
	}
	void Start(){
		ListPlanets ();
	}
	void ListPlanets ()
	{
		planets = GameObject.FindGameObjectsWithTag ("Planet");
		if (planets.Length > 0) {
			currentPlanet = planets [planetIndex];
		}
	}



	public void NextPlanet ()
	{
		Debug.Log ("PlanetCount:" +planets.Length);
		if (planets.Length > 0) {
			if (planetIndex >= planets.Length - 1) {
				planetIndex = 0;
			} else {
				planetIndex++;
			}
			currentPlanet = planets [planetIndex];
		}
		Debug.Log ("Current Planet Index: " + planetIndex);
	}

	public void PreviousPlanet ()
	{
		Debug.Log ("PlanetCount:" +planets.Length);
		if (planets.Length > 0) {
			if (planetIndex == 0) {
				planetIndex = planets.Length - 1;
			} else {
				planetIndex--;
			}
			currentPlanet = planets [planetIndex];
		}
		Debug.Log ("Current Planet Index: " + planetIndex);
	}
}
