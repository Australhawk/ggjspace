using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	private GameObject currentSelectedPlanet;

	private GameObject lastSelectedPlanet;
	public float cameraDistance = 20f;
	public float cameraHeight = 5f;
	public float cameraSpeed = 2f;
	public float distance = 100;
	// Use this for initialization
	void Start () {
		this.currentSelectedPlanet = GameManager.instance.currentPlanet;
	}

	void Update()
	{
		this.currentSelectedPlanet = GameManager.instance.currentPlanet;
		if(this.currentSelectedPlanet != null){
			// Focus Camera to Planet and Change LastSelectedPlanet
			if (lastSelectedPlanet == null || (lastSelectedPlanet.GetInstanceID() != currentSelectedPlanet.GetInstanceID())) {
				FocusOnPlanet ();
			} else {
				FollowPlanet ();
			}
		}
	}

	// Moves the camera towards the current selected planet
	void FocusOnPlanet ()
	{
		this.lastSelectedPlanet = this.currentSelectedPlanet;
		Vector3 currentSelectedPosition = this.currentSelectedPlanet.transform.position;
		Vector3 currentPlaceholderPosition = this.currentSelectedPlanet.GetComponent<Planet> ().planetPlaceholder.transform.position;
		Vector3 newPosition = (currentPlaceholderPosition - currentSelectedPosition).normalized * cameraDistance + currentSelectedPosition;
		newPosition = new Vector3 (newPosition.x, cameraHeight, newPosition.z);
		transform.position = newPosition;
		transform.LookAt (currentSelectedPlanet.transform.position);
	}

	void FollowPlanet ()
	{
		Vector3 currentSelectedPosition = this.currentSelectedPlanet.transform.position;
		Vector3 xyPosition = new Vector3 (transform.position.x, 0, transform.position.z);
		Vector3 newPosition = currentSelectedPosition + (currentSelectedPosition - xyPosition).normalized * cameraDistance;
		transform.position = newPosition;
		Vector3 pivot = this.currentSelectedPlanet.transform.position;
		var mousePosition = Input.mousePosition;

		if (mousePosition.x < distance) {
			transform.RotateAround (pivot, Vector3.up, Mathf.Abs (mousePosition.x - distance) / 100);
		} else if (mousePosition.x > Screen.width - distance) {
			transform.RotateAround (pivot, Vector3.down, (mousePosition.x - Screen.width + distance) / 100);
		}
		//transform.LookAt (pivot);
	}
}
