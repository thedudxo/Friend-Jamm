using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour {

    public Transform newTarget;
    public Transform currentTarget;
    public Vector3 offset;
    public bool noSwitch = false;
    private static SwitchManager instance;

    public static SwitchManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<SwitchManager>();
            }
            return SwitchManager.instance;
        }
    }

    private void Awake() {
        StartCoroutine(Starter());
    }

    public IEnumerator Switch() {
        Vector3 from = currentTarget.position + offset;
        Vector3 to = newTarget.position + offset;
        float elapsed = 0.0f;
        float duration = 0.6f;
        while (elapsed < duration) {
            transform.Rotate(Vector3.forward * Time.deltaTime * 1000);
            transform.position = Vector3.Lerp(from, to, elapsed/duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        noSwitch = false;
        currentTarget = newTarget;
        this.gameObject.SetActive(false);
    }

    public IEnumerator Starter() {
        yield return new WaitForSeconds(0.1f);
        transform.position = currentTarget.position;
        this.gameObject.SetActive(false);
        yield return null;
    }
}
