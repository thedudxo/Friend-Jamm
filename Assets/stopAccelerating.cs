﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class stopAccelerating : MonoBehaviour {

    public PlayerManager player1;
    public PlayerManager player2;
    public GameObject noLeave;
    public bool disableGRavity;

    bool hasWon = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (disableGRavity)
        {
            player1.gameObject.GetComponent<Rigidbody>().useGravity = false;
            player2.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
        else { if (!hasWon) { Analytics.CustomEvent("win"); Debug.Log("oh wow you won"); hasWon = true; } }

        noLeave.SetActive(true);
        SwitchManager.Instance.noSwitch = true;
        
    }
}
