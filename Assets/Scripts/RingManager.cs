using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour {
    public List<RingController> rings;
    // Use this for initialization
    void OnSceneEnter() {
        RegisterRings();
    }

    // Update is called once per frame
    void Update() {

    }

    public void RegisterRings() {
        if (this.rings==null) {
            this.rings = new List<RingController>();
        } else {
            this.rings.Clear();
        }
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
            GameManager.instance.level += 1;
            SceneManager.ChangeScene("Level_" + GameManager.instance.level);
        }
    }
}
