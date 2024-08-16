using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public Camera sceneCamera;
    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private float step;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {

        }
    }
}
