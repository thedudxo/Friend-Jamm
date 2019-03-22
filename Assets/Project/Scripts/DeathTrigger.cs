using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour {
    
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other) {
        StartCoroutine(PlayerManager.Instance.Death());
    }
}
