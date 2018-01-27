using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIntro : MonoBehaviour {

	public Transform followTarget;
	public Vector3 offset = new Vector3(10f,0,0);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = followTarget.position + offset;
	}
}
