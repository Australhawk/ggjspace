using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

	// Import ScriptableObject Data
	public PlanetObject planetObject;
	// Planet Placeholder
	public GameObject planetPlaceholder;
	// Use this for initialization
	void Start () {

		// Set RigidbodyMass
		Rigidbody rigidbody = GetComponent<Rigidbody>();
		if (rigidbody != null) {
			rigidbody.mass = this.planetObject.planetMass;
		}
		// Set Planet Radius On Object and Placeholder
		if (this.planetObject.planetRadius > 0f) {
			float diameter = this.planetObject.planetRadius * 2f;
			this.transform.localScale = new Vector3 (diameter, diameter, diameter);	
			if (this.planetPlaceholder) {
				this.planetPlaceholder.transform.localScale = new Vector3 (diameter, diameter, diameter);	
			}
		}
		// Set Planet Material
		if (this.planetObject.texture != null) {
			GetComponent<Renderer> ().material.SetTexture ("_MainTex",this.planetObject.texture);
			if (this.planetPlaceholder) {
				this.planetPlaceholder.GetComponent<Renderer> ().material.SetTexture ("_MainTex",this.planetObject.texture);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
