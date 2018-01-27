using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

	// Import ScriptableObject Data
	public PlanetObject planetObject;
	// Use this for initialization
	void Start () {

		// Set RigidbodyMass
		Rigidbody rigidbody = GetComponent<Rigidbody>();
		if (rigidbody != null) {
			rigidbody.mass = this.planetObject.planetMass;
		}
		// Set Planet Radius
		if (this.planetObject.planetRadius != null) {
			float diameter = this.planetObject.planetRadius * 2;
			this.transform.localScale = new Vector3 (diameter, diameter, diameter);	
		}
		// Set Planet Material
		if (this.planetObject.material != null) {
			GetComponent<Renderer> ().material = this.planetObject.material;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
