using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour {
    

    private void OnTriggerEnter(Collider other) {
       // StartCoroutine(other.GetComponent<DeathScript>().Death());
        //StartCoroutine(DeathScript.Instance.Death());
    }
}
