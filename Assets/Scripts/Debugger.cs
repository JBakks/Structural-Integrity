using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Oculus.Interaction;
using Oculus.Interaction.Input;

// A debugger to help in the development process
public class Debugger : MonoBehaviour
{
    public TMP_Text debugText;

    string additionalDebugText;

    public ControllerPointerPose rayOriginasPose;

    public Transform rayOrigin;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        debugText.text = "Ray Origin as Pose: " + rayOriginasPose.ToString() + "\n Ray Origin as Transform: Pos: " + rayOrigin.position + " Rotation: " + rayOrigin.rotation + " Scale: " + rayOrigin.localScale + additionalDebugText;
    }

    public void AddText(string text)
    {
        additionalDebugText += "\n"+text;
    }
}
