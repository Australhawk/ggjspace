using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

    // Import ScriptableObject Data
    public Vector3 initialPos;
    public PlanetObject planetObject;
    public AudioClip lose;
    private bool finished;
    private Vector3 velocity;
    
    // Use this for initialization
    void Start() {
        initialPos = transform.position;
        finished = false;
        // Set RigidbodyMass
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody == null) {
            rigidbody = this.gameObject.AddComponent<Rigidbody>();
        }
        if (rigidbody != null) {
            if (this.planetObject) {
                rigidbody.mass = this.planetObject.planetMass;
            }
            rigidbody.useGravity = false;
            rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        }
        // Set Planet Radius On Object and Placeholder
        if (this.planetObject && this.planetObject.planetRadius > 0f) {
            float diameter = this.planetObject.planetRadius * 2f;
            this.transform.localScale = new Vector3(diameter, diameter, diameter);
        }
    }

    public void AddForce(float force) {
        if (!finished) {
            //Debug.Log("Adding Force");
            Rigidbody rigidbody = GetComponent<Rigidbody>();

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            if (Physics.Raycast(ray, out hit)) {
                rigidbody.velocity = new Vector3(0, 0, 0);
                //Debug.Log("Just Hit: " + hit.collider.gameObject.tag);
                //Debug.Log("Adding Force at: " + hit.point + " to: " + Camera.main.transform.forward);
                rigidbody.AddForceAtPosition(Camera.main.transform.forward * force, hit.point, ForceMode.VelocityChange);
            }
        }
    }

    // Update is called once per frame
    void Update () {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (finished) {
            rigidbody.velocity = Vector3.zero;
        }
        rigidbody.velocity *= 0.95f;
    }

    internal void Pause() {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        this.velocity = rigidbody.velocity;
        rigidbody.velocity = Vector3.zero;
    }
    internal void Resume() {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = this.velocity;
    }

    /**
     * Lose check! :o
     */ 
    private void OnCollisionEnter(Collision collision) {
        AudioSource asource = GameObject.Find("CameraPivot").GetComponent<AudioSource>();
        asource.clip = lose;
        asource.Play();
    }

    void OnTriggerEnter(Collider other) {
        RingController rc = other.GetComponent<RingController>();
        if (rc != null) {
            rc.PlanetEntered(this);
        }
    }
    private void OnTriggerExit(Collider other) {
        RingController rc = other.GetComponent<RingController>();
        if (rc != null) {
            rc.PlanetExited(this);
        }
    }

    public bool Finished {
        get {
            return finished;
        }

        set {
            finished = value;
        }
    }
}
