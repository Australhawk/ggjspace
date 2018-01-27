using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	private GameObject currentSelectedPlanet;

	private GameObject lastSelectedPlanet;
	public float cameraDistance = 20f;
	public float cameraHeight = 5f;
	public float cameraSpeed = 2f;
	public float screenDistance = 100;
	public float radiusSpeed = 100f;
	// Use this for initialization
	void Start () {
		this.currentSelectedPlanet = GameManager.instance.currentPlanet;
	}

	void LateUpdate()
	{
		this.currentSelectedPlanet = GameManager.instance.currentPlanet;
		if(this.currentSelectedPlanet != null){
			// Focus Camera to Planet and Change LastSelectedPlanet
			if (lastSelectedPlanet == null || (lastSelectedPlanet.GetInstanceID() != currentSelectedPlanet.GetInstanceID())) {
				//FocusOnPlanet ();
				FollowPlanet ();
				//TestMethod();
			} else {
				FollowPlanet ();
				//TestMethod();
			}
		}
	}

	void TestMethod() {
		transform.LookAt (currentSelectedPlanet.transform);
		var mousePosition = Input.mousePosition;
		Vector3 pivot = this.currentSelectedPlanet.transform.position;
		if (mousePosition.x < screenDistance) {
			transform.RotateAround (pivot, Vector3.up, Mathf.Abs (mousePosition.x - screenDistance) / 100);
		} else if (mousePosition.x > Screen.width - screenDistance) {
			transform.RotateAround (pivot, Vector3.down, (mousePosition.x - Screen.width + screenDistance) / 100);
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
		Vector3 pivot = this.currentSelectedPlanet.transform.position;
		var mousePosition = Input.mousePosition;

		if (mousePosition.x < screenDistance) {
			transform.RotateAround (pivot, Vector3.up, Mathf.Abs (mousePosition.x - screenDistance) / 100);
		} else if (mousePosition.x > Screen.width - screenDistance) {
			transform.RotateAround (pivot, Vector3.down, (mousePosition.x - Screen.width + screenDistance) / 100);
		}
		Vector3 desiredPosition = (transform.position - pivot).normalized * cameraDistance + pivot;
		transform.position = Vector3.MoveTowards(transform.position, desiredPosition, 100f);
		Camera.main.transform.LookAt (pivot);
	}
}
