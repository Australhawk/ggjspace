using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidIntro : MonoBehaviour {

	public float speed = 10f;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().velocity = new Vector3 (1, -1, 0) * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
