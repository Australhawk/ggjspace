using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	[HideInInspector]
	public bool playing = false;
	[HideInInspector]
	public string currentMicrophoneDevice;
	public static GameManager instance;

	// Use this for initialization
	void Start () {

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
