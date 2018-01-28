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
        this.transform.LookAt(currentRing.transform);
        this.transform.position = currentPlanet.transform.position+Vector3.up*3;
	}
}
