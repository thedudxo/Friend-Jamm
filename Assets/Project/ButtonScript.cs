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
        buttonAnim.SetBool("isPressed", true);
        foreach (Animator press in hydrolicPress) {
            press.SetBool("isPressed", true);
            Debug.Log(press.GetBool("isPressed"));
        }
    }

    private void OnCollisionExit(Collision collision) {
        buttonAnim.SetBool("isPressed", false);
        foreach (Animator press in hydrolicPress) {
            press.SetBool("isPressed", false);
            Debug.Log(press.GetBool("isPressed"));
        }
    }
}
