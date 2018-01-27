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

	public void AddForce (float force)
	{
		Debug.Log ("Adding Force");
		Rigidbody rigidbody = GetComponent<Rigidbody> ();

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2,Screen.height/2));
		if (Physics.Raycast(ray, out hit)) {
			rigidbody.velocity = new Vector3(0,0,0);
			Debug.Log ("Just Hit: "+hit.collider.gameObject.tag);
			Debug.Log ("Adding Force at: " + hit.point + " to: " + Camera.main.transform.forward);
			rigidbody.AddForceAtPosition (Camera.main.transform.forward*force,hit.point,ForceMode.VelocityChange);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
