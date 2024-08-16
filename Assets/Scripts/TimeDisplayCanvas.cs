using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using Oculus.Interaction.Input;

namespace Oculus.Interaction
{

}
public class TimeDisplayCanvas : MonoBehaviour
{
    public GameObject Timer;
    public TMP_Text timeText;

    public bool useCountUpTimer; // Toggle to use CountUpTimer

    public GameObject player;
    public Debugger debugger;

    public ControllerRef LeftController;

    public bool toggleAllowed;
    // Start is called before the first frame update
    void Start()
    {
        toggleAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCanvasText();
        UpdateCanvasPos();
        if (OVRInput.Get(OVRInput.RawButton.Y))
        {
            StartCoroutine(ToggleCanvas());
        }
    }

    IEnumerator ToggleCanvas()
    {
        if (toggleAllowed)
        {
            toggleAllowed = false;
            //debugger.AddText("X button pressed");
            if (CanvasEnabled())
            {
                //debugger.AddText("Timer Canvas was enabled so disabling it");
                DisableCanvas();
                yield return new WaitForSeconds(0.4f);
            }
            else
            {
                //debugger.AddText("Timer Canvas was disabled so enabling it");
                EnableCanvas();
                //debugger.AddText("Updating Timer Canvas Postion");
                UpdateCanvasPos();
                yield return new WaitForSeconds(0.4f);
            }
            toggleAllowed = true;
        }

        
    }

    public bool CanvasEnabled()
    {
        return Timer.activeSelf;
    }
    public void EnableCanvas()
    {
        Timer.SetActive(true);
    }

    public void DisableCanvas()
    {
        Timer.SetActive(false);
    }

    public void UpdateCanvasText()
    {
        if (useCountUpTimer)
        {
            timeText.text = CountUpTimer.instance.GetFormattedTime(); // Use CountUpTimer if enabled
        }
        else
        {
            timeText.text = CountdownTimer.instance.GetFormattedTime();
        }
    }

    public void UpdateCanvasPos()
    {
        if (LeftController.TryGetPose(out Pose rootPose))
        {
            //debugger.AddText("Controller Position: " + rootPose.position);
            Timer.transform.position = rootPose.position + Vector3.up * 0.2f;
            //Timer.transform.rotation = rootPose.rotation;
            Timer.transform.LookAt(player.transform.position);
            Timer.transform.Rotate(Vector3.up, -180);
        }
    }
}
