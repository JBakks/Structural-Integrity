using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.Input;
using UnityEngine;

public class LeftHandPositioner : MonoBehaviour
{
    public ControllerRef LeftController;
    public GameObject player;
    public float distanceFromController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCanvasPos();
    }

    public void UpdateCanvasPos()
    {
        if (LeftController.TryGetPose(out Pose rootPose))
        {
            //debugger.AddText("Controller Position: " + rootPose.position);
            transform.position = rootPose.position + Vector3.up * 0.2f + new Vector3(0f,0f,distanceFromController);
            //Timer.transform.rotation = rootPose.rotation;
            transform.LookAt(player.transform.position);
            transform.Rotate(Vector3.up, -180);
        }
    }
}
