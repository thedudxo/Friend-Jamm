using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class BucketSimulator : MonoBehaviour {

    public GameObject stupidReference;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        stupidReference.SetActive(true);
        Analytics.CustomEvent("Bucket");
    }
}
