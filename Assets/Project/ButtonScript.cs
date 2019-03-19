using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    public bool isPressed = false;
    public List<GameObject> hydrolicPress;
    public Material work;
    private Animator buttonAnim;

    private void Start() {
        buttonAnim = GetComponent<Animator>();
        work.DisableKeyword("_EMISSION");
    }

    private void OnCollisionEnter(Collision collision) {
        buttonAnim.SetBool("isPressed", true);
        foreach (GameObject press in hydrolicPress) {
            press.GetComponentInChildren<Animator>().SetBool("isPressed", true);
            press.GetComponentInChildren<Renderer>().material.DisableKeyword("_EMISSION");
        }
    }

    private void OnCollisionExit(Collision collision) {
        buttonAnim.SetBool("isPressed", false);
        foreach (GameObject press in hydrolicPress) {
            press.GetComponentInChildren<Animator>().SetBool("isPressed", false);
            press.GetComponentInChildren<Renderer>().material.EnableKeyword("_EMISSION");
        }
    }
}
