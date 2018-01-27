using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	private GameObject currentSelectedPlanet;

	private GameObject lastSelectedPlanet;
	public float cameraDistance = 10f;
	public float cameraHeight = 5f;

	public float smoothTime = 0.1f;
	public float speed = 3.0f;

	public float horizontalBuffer = 0f;

	private Vector3 velocity = Vector3.zero;

	public Quaternion rotation = Quaternion.identity;

	public float yRotation = 0.0f;

	// Use this for initialization
	void Start () {
		this.currentSelectedPlanet = GameManager.instance.currentPlanet;
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
	void FocusOnPlanet() {
		this.lastSelectedPlanet = this.currentSelectedPlanet;
		Vector3 currentSelectedPosition = this.currentSelectedPlanet.transform.position;
		Vector3 currentPlaceholderPosition = this.currentSelectedPlanet.GetComponent<Planet> ().planetPlaceholder.transform.position;
		transform.position = currentSelectedPosition - currentPlaceholderPosition + new Vector3(cameraDistance,cameraHeight,cameraDistance);
		transform.LookAt (currentSelectedPlanet.transform.position);
	}
		
	void FollowPlanet () {
		Vector3 targetPosition = this.currentSelectedPlanet.transform.TransformPoint(new Vector3(horizontalBuffer, cameraDistance, cameraHeight));
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
		transform.eulerAngles = new Vector3(this.currentSelectedPlanet.transform.eulerAngles.x, 0, this.currentSelectedPlanet.transform.eulerAngles.z);
	}
}
