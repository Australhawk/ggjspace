using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour {


    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Planet")
        {
            other.transform.position = other.GetComponent<Planet>().initialPos;
        }
    }
}
