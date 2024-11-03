using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRInputTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out hit))
            {
                EventManager.TriggerObjectClicked(hit.transform.name);
            }
        }
        
    }
}
