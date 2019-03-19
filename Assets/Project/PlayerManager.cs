using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public CameraScript camScript;
    public KeyCode SwitchChar;
    public GameObject switchEffect;
    private Rigidbody rb;
    private float accel = 200;
    private float maxSpeed = 5;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        float speed = rb.velocity.magnitude;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        if (rb.velocity.x < maxSpeed || rb.velocity.z < maxSpeed) {
            float ignore = rb.velocity.y;
            Vector3 notThis = movement * maxSpeed;
            notThis.y = ignore;
            rb.velocity = notThis;
        }
        rb.AddForce(moveHorizontal * accel * Time.deltaTime, 0, moveVertical * accel * Time.deltaTime);
        if (movement != Vector3.zero) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.15f);
        }
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