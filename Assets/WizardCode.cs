using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardCode : MonoBehaviour {

    public GameObject[] greenBlocks;
    public GameObject[] blueBlocks;
    public GameObject[] redBlocks;

    public bool redDown, blueDown, greenDown;

    // Use this for initialization
    void Start()
{

}

// Update is called once per frame
void Update()
{
    if (Input.GetKeyDown(KeyCode.R) && redDown == false)
        {
            for (int i = 0; i < redBlocks.Length; i++)
            {
                redBlocks[i].transform.position += new Vector3(0, 2.63f, 0);
                blueBlocks[i].transform.position += new Vector3(0, -2.63f, 0);
                
            }
            redDown = true;
            blueDown = false;
            
        }

        if (Input.GetKeyDown(KeyCode.B) && blueDown == false)
        {
            for (int i = 0; i < blueBlocks.Length; i++)
            {
                blueBlocks[i].transform.position += new Vector3(0, 2.63f, 0);
                greenBlocks[i].transform.position += new Vector3(0, -2.63f, 0);
                
            }
            blueDown = true;
            greenDown = false;
            
        }

        if (Input.GetKeyDown(KeyCode.G) && greenDown == false)
        {
            for (int i = 0; i < greenBlocks.Length; i++)
            {
                greenBlocks[i].transform.position += new Vector3(0, 2.63f, 0);
                redBlocks[i].transform.position += new Vector3(0, -2.63f, 0);
               
            }
            greenDown = true;
            redDown = false;
            

        }






    }
}
