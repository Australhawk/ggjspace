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

	void FollowPlanet ()
	{
        if (!GameManager.instance.playing) {
            return;
        }
		Vector3 pivot = this.currentSelectedPlanet.transform.position;
		var mousePosition = Input.mousePosition;
        if (Input.GetKey(KeyCode.A)) {
            transform.RotateAround(pivot, Vector3.down, 0.6f);
		} else if (Input.GetKey(KeyCode.D)) {
			transform.RotateAround (pivot, Vector3.up, 0.6f);
		}
		Vector3 desiredPosition = (transform.position - pivot).normalized * cameraDistance + pivot;
		transform.position = Vector3.MoveTowards(transform.position, desiredPosition, 100f);
		Camera.main.transform.LookAt (pivot);
	}
}
