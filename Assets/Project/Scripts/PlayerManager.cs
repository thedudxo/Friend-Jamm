using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public CameraScript camScript;
    public GameObject otherPlayer;
    public KeyCode SwitchChar;
    public GameObject switchEffect;
    public Transform switchRay;
    public Vector3 spawn;
    private Rigidbody rb;
    private float accel = 200;
    private float maxSpeed = 3;
    public bool dead = false;
    private static PlayerManager instance;
    public static PlayerManager Instance {
        get {
            if (instance == null) {
                instance = GameObject.FindObjectOfType<PlayerManager>();
            }
            return PlayerManager.instance;
        }
    }

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        if (dead || SwitchManager.Instance.noSwitch) { return; }
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
        if (Input.GetKeyDown(SwitchChar) && !SwitchManager.Instance.noSwitch) {
            otherPlayer.GetComponent<PlayerManager>().enabled = true;
            switchEffect.transform.position = this.transform.position;
            switchEffect.SetActive(true);
            SwitchManager.Instance.newTarget = otherPlayer.transform;
            SwitchManager.Instance.noSwitch = true;
            camScript.target = otherPlayer.transform;
            this.GetComponent<PlayerManager>().enabled = false;
            StartCoroutine(SwitchManager.Instance.Switch());
        }
        Debug.DrawRay(switchRay.position, transform.forward * 3);
    }

    public IEnumerator Death() {
        dead = true;
        yield return new WaitForSeconds(2);
        this.transform.position = spawn;
        dead = false;
        yield return null;
    }
}