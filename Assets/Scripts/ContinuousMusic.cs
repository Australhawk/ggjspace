using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousMusic : MonoBehaviour {

    public static ContinuousMusic instance;

    void Awake()
    {

        // Create GameManager Instance or destroy if another one exists
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}
