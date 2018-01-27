using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public GameObject currentSelectedPlanet;

	private GameObject lastSelectedPlanet;
	public float cameraDistance = 10f;
	public float cameraHeight = 5f;

	private Vector3 offset;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Focus Camera to Planet and Change LastSelectedPlanet
		if (currentSelectedPlanet != lastSelectedPlanet) {
			FocusOnPlanet ();
		} else {
			FollowPlanet ();
		}
		FocusOnPlanet ();
	}

	// Moves the camera towards the current selected planet
	void FocusOnPlanet ()
	{
		this.lastSelectedPlanet = this.currentSelectedPlanet;
		Vector3 currentSelectedPosition = this.currentSelectedPlanet.transform.position;
		Vector3 currentPlaceholderPosition = this.currentSelectedPlanet.GetComponent<Planet> ().planetPlaceholder.transform.position;
		transform.position = currentSelectedPosition - currentPlaceholderPosition + new Vector3(cameraDistance,cameraHeight,cameraDistance);
		offset = transform.position - currentSelectedPosition;
		transform.LookAt (currentSelectedPlanet.transform.position);
	}

	void FollowPlanet ()
	{
		Vector3 currentSelectedPosition = this.currentSelectedPlanet.transform.position;
		transform.position = currentSelectedPosition + offset;
	}
}
