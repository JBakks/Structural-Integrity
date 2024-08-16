using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using Oculus.Interaction.Input;
using TMPro;

public class HighlightDamage : MonoBehaviour
{
    public GameObject curvedCanvas;

    public GameObject pinPrefab;

    //public ControllerPointerPose rControllerRay;

    public RayInteractor rRayInteractor;

    public Debugger debugger;

    public GameObject player;

    Vector3 hitPoint;

    bool pinDropAllowed;

    bool RTriggerPressed;

    Damage[] damages;

    Damage damageSelected;

    PointableUnityEventWrapper pinPointEvent;

    private void Start()
    {
        damages = Resources.LoadAll<Damage>("Damage");
        damageSelected = null;
        pinDropAllowed = false;
        RTriggerPressed = false;
    }

    private void Update()
    {
        //Checkes if the right index trigger is clicked and it is on the bridge. If so, it enables the canvas to select a damage
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            if (Physics.Raycast(rRayInteractor.Ray, out RaycastHit hitInfo, rRayInteractor.MaxRayLength))
            {
                //debugger.AddText("\nRay Casted");
                if (hitInfo.collider.tag == "ground" && !RTriggerPressed)
                {
                    //debugger.AddText("\nGround touched and canvas not active");
                    hitPoint = hitInfo.point;
                    //curvedCanvas.transform.position = hitPoint + Vector3.up;
                    //curvedCanvas.transform.LookAt(player.transform);
                    //curvedCanvas.transform.Rotate(Vector3.up, -180);
                    curvedCanvas.SetActive(true);
                    LeftHandUIController.instance.ToggleUI(curvedCanvas);
                    pinDropAllowed = true;
                    RTriggerPressed = true;
                }
            }
        }

        if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger))
        {
            RTriggerPressed = false;
        }
        //Checkes if a damage has been selected, then puts the pin the world.
        if (pinDropAllowed && damageSelected != null)
        {
            //debugger.AddText("\nDamage selected: " + damageSelected.damageName);

            GameObject pin = Instantiate(pinPrefab);
            pin.transform.position = hitPoint;

            //debugger.AddText("\nHit Position: " + hitPoint);

            DamageType dmgType = pin.GetComponent<DamageType>();
            dmgType.damageType = damageSelected;
            
            Renderer pinRenderer = pin.GetComponent<Renderer>();
            pinRenderer.material.color = damageSelected.color.color;
            //debugger.AddText("Damage Color: " + pin.GetComponent<Renderer>().material.color);

            pin.SetActive(true);

            //debugger.AddText("\nPin Info: " + pin.activeSelf + " " + pin.name);
            pinDropAllowed = false;

            damageSelected = null;
        }
    }

    //Receives the selected damage from the dropdown
    public void SelectedDamage(TMP_Dropdown dropdown)
    {
        //debugger.AddText("\nSelected Damage function Called");
        foreach (Damage damage in damages)
        {
            if (damage.damageName == dropdown.options[dropdown.value].text)
            {
                //debugger.AddText("\nSelected Damage found");
                damageSelected = damage;
            }
        }
    }
}