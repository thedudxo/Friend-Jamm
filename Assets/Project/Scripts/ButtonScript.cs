using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    public bool isPressed = false;
    public List<GameObject> hydrolicPress;
    public GameObject button;
    public Material pressOn;
    public Material pressOff;
    public Material buttonOn;
    public Material buttonOff;
    private Animator buttonAnim;

    private void Start() {
        buttonAnim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision) {
        buttonAnim.SetBool("isPressed", true);
        Renderer[] mats = button.GetComponentsInChildren<Renderer>();
        foreach (Renderer buttonMats in mats) {
            buttonMats.material = buttonOn;
        }
        foreach (GameObject press in hydrolicPress) {
            press.GetComponentInChildren<Animator>().SetBool("isPressed", true);
            Renderer[] foo = press.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in foo) {
                renderer.material = pressOn;
            }
        }
    }

    private void OnCollisionExit(Collision collision) {
        buttonAnim.SetBool("isPressed", false);
        Renderer[] mats = button.GetComponentsInChildren<Renderer>();
        foreach (Renderer buttonMats in mats) {
            buttonMats.material = buttonOff;
        }
        foreach (GameObject press in hydrolicPress) {
            press.GetComponentInChildren<Animator>().SetBool("isPressed", false);
            Renderer[] foo = press.GetComponentsInChildren<Renderer>();
            foreach(Renderer renderer in foo) {
                renderer.material = pressOff;
            }
        }
    }
}
