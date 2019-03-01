using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public CameraScript camScript;
    public KeyCode SwitchChar;
    public GameObject switchEffect;
    private Rigidbody rb;
    private float accel = 12;
    private float maxSpeed = 600;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        float speed = rb.velocity.magnitude;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (movement != Vector3.zero) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.15f);
        }
        rb.velocity = Vector3.Lerp(rb.velocity, movement * maxSpeed * Time.deltaTime, accel);
        Ray ray;
        RaycastHit hit;
        ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, 3.0f) && hit.collider.tag == "Character") {
            if (Input.GetKeyDown(SwitchChar)) {
                hit.collider.gameObject.GetComponent<PlayerManager>().enabled = true;
                switchEffect.transform.position = this.transform.position;
                switchEffect.SetActive(true);
                SwitchManager.Instance.newTarget = hit.transform;
                StartCoroutine(SwitchManager.Instance.Switch());
                camScript.target = hit.transform;
                this.GetComponent<PlayerManager>().enabled = false;
            }
        }
        Debug.DrawRay(transform.position, transform.forward * 3);
    }
}