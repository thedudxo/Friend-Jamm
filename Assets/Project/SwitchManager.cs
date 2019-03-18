using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour {

    public Transform newTarget;
    public Transform currentTarget;
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

    public IEnumerator Switch() {
        Vector3 from = currentTarget.position;
        Vector3 to = newTarget.position;
        float elapsed = 0.0f;
        float duration = 0.6f;
        while (elapsed < duration) {
            transform.Rotate(Vector3.forward * Time.deltaTime * 500);
            transform.position = Vector3.Lerp(from, to, elapsed/duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        currentTarget = newTarget;
        this.gameObject.SetActive(false);
    }

}
