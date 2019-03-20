using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Transform target;
    public float smoothSpeed = 0.5f;
    public Vector3 offset;

    private void Start() {
        Application.targetFrameRate = 60;
    }

    void LateUpdate () {
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothedPos;
	}
}