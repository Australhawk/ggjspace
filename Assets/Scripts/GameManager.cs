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
	
	// Update is called once per frame
	void Update () {
		
	}
}
