﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToIntro : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (Wait ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator Wait(){
		yield return new WaitForSeconds (4);
		CustomSceneManager.ChangeScene ("Intro");
	}
}
