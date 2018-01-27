using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMovement : MonoBehaviour {


    [SerializeField] Transform targetOrbit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(targetOrbit.position, targetOrbit.position, 20 * Time.deltaTime);
	}
}
