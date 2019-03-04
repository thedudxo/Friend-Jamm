using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    public bool isPressed = false;
    public List<Animator> hydrolicPress;
    
    private void OnCollisionEnter(Collision collision) {
        Debug.Log("Collided with " + collision.gameObject);
        foreach (Animator anim in hydrolicPress) {
            anim.SetBool("isPressed", true);
        }
    }

    private void OnCollisionExit(Collision collision) {
        foreach (Animator anim in hydrolicPress) {
            anim.SetBool("isPressed", false);
        }
    }
}
