using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    public bool isPressed = false;
    public List<Animator> hydrolicPress;
    private Animator buttonAnim;

    private void Start() {
        buttonAnim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("Collided with " + collision.gameObject);
        buttonAnim.SetBool("isPressed", true);
        foreach (Animator anim in hydrolicPress) {
            anim.SetBool("isPressed", true);
        }
    }

    private void OnCollisionExit(Collision collision) {
        buttonAnim.SetBool("isPressed", false);
        foreach (Animator anim in hydrolicPress) {
            anim.SetBool("isPressed", false);
        }
    }
}
