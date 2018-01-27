using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour {
    public List<RingController> rings;
    // Use this for initialization
    void Start() {
        RegisterRings();
    }

    // Update is called once per frame
    void Update() {

    }

    void RegisterRings() {
        GameObject[] rings = GameObject.FindGameObjectsWithTag("Ring");
        foreach (GameObject gameObject in rings) {
            RingController ring = gameObject.GetComponent<RingController>();
            this.rings.Add(ring);
            Debug.Log("Adding Rings: "+ring.name);
        }
    }

    public void RingFinished(RingController ring) {
        rings.Remove(ring);
        Debug.Log(rings.Count);
        if (rings.Count < 1) {
            //WE FINISHED THE LEVEL!
            Debug.Log("LEVEL FINISHED :D");
        }
    }
}
