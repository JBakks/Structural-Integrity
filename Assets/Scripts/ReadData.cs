using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Oculus.Interaction;
using Oculus.Interaction.Input;

public class ReadData : MonoBehaviour
{
    GameObject DamageInfoCurvedCanvas;

    GameObject RemoveDamageCanvas;
    
    DamageType selectedDamage;

    ShowDamage showDamage;

    GameObject player;

    Debugger debugger;

    DeletePin deletePin;

    bool isCanvasOn;

    //Gets all the neccessary objects from the scene
    private void Start()
    {
        
        selectedDamage = gameObject.GetComponent<DamageType>();
        if (selectedDamage == null)
        {
            debugger.AddText("Damage not found");
        }

        DamageInfoCurvedCanvas = FindObjectByName("See Damage Canvas");
        if (DamageInfoCurvedCanvas == null)
        {
            Debug.LogError("Damage info curved canvas not found");
        }

        RemoveDamageCanvas = FindObjectByName("Remove Damage Canvas");
        if (RemoveDamageCanvas == null)
        {
            Debug.LogError("Remove pin canvas not found");
        }

        showDamage = FindObjectByName("GameController").GetComponent<ShowDamage>();
        if (showDamage == null)
        {
            debugger.AddText("show damage not found");
        }
        

        player = FindObjectByName("PlayerController");
        if (player == null)
        {
            Debug.LogError("player not found");
        }
        

        Transform parentTransform = FindObjectByName("DebugPanel").transform;
        Transform childTransform = parentTransform.Find("Debugger");
        debugger = childTransform.gameObject.GetComponent<Debugger>();
        if (debugger == null)
        {
            Debug.LogError("Debugger not found");
        }


        //debugger.AddText("\nDebugger found from prefab");
        deletePin = RemoveDamageCanvas.GetComponent<DeletePin>();

        isCanvasOn = false;
    }

    //Finds an object in the scene by name
    GameObject FindObjectByName(string name)
    {
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach (GameObject obj in objects)
        {
            if (obj.name == name)
            {
                return obj;
            }
        }

        return null;
    }

    //Called when the pin is hovered at and unhovered from
    public void HandlePointerEvent(PointerEvent pointerEvent)
    {
        Pose pointedTransform = (Pose)pointerEvent.Pose;

        PointerEventType pointerEventType = pointerEvent.Type;

        ChooseAction(pointerEventType, pointedTransform);

        //DamageInfoCurvedCanvas = Instantiate(DamageInfoCurvedCanvasPrefab);
    }

    //Called if the pin is hovered at
    void HoveredAction(Pose hoverData)
    {
        debugger.AddText("Hovered on Pin");
        //debugger.AddText("Hovered On Curved Canvas: Position: " + DamageInfoCurvedCanvas.transform.position + " Canvas Text: " + showDamage.GetText() + " Is Canvas Active: " + DamageInfoCurvedCanvas.activeSelf);

        //DamageInfoCurvedCanvas.transform.position = hoverData.position + Vector3.up;
        //DamageInfoCurvedCanvas.transform.LookAt(player.transform);
        //DamageInfoCurvedCanvas.transform.Rotate(Vector3.up, 180);

        showDamage.PopulateCanvas(selectedDamage);

        debugger.AddText("Populated Show canvas");
        DamageInfoCurvedCanvas.SetActive(true);
        LeftHandUIController.instance.ToggleUI(DamageInfoCurvedCanvas);
        debugger.AddText("Enabled Show canvas");

        
        isCanvasOn = true; 
    }

    //Called if the pin is unhovered from
    void UnHoveredAction()
    {
        //debugger.AddText("Not Hovered on Pin");
        DamageInfoCurvedCanvas.SetActive(false);
        //debugger.AddText("Unhovered on Curved Canvas: Is canvas Active: " + DamageInfoCurvedCanvas.activeSelf);
        isCanvasOn = false;
    }

    //Called if the pin is selected
    void SelectedAction(Pose rayTransformData)
    {
        RemoveDamageCanvas.SetActive(true);
        LeftHandUIController.instance.ToggleUI(RemoveDamageCanvas);
        //debugger.AddText("Remove Damage canvas activated");

        RemoveDamageCanvas.transform.position = rayTransformData.position + Vector3.up;
        RemoveDamageCanvas.transform.LookAt(player.transform);
        RemoveDamageCanvas.transform.Rotate(Vector3.up, 180);

        DamageInfoCurvedCanvas.SetActive(false);

        DamageType dmgSelected = GetComponent<DamageType>();
        //debugger.AddText(dmgSelected.damageType.damageName);

        deletePin.SetPin(gameObject);
        //debugger.AddText("Pin to be deleted Set");
    }
    //Depending on the pointer event type the hover or unhover function is called
    void ChooseAction (PointerEventType pointerEventType, Pose pointedTransform)
    {
        if (pointerEventType.Equals(PointerEventType.Hover))
        {
            HoveredAction(pointedTransform);
        }
        if (pointerEventType.Equals(PointerEventType.Unhover))
        {
            UnHoveredAction();
        }
        if (pointerEventType.Equals(PointerEventType.Select))
        {
            SelectedAction(pointedTransform);
            //debugger.AddText("Pin Selected!");
        }
    }
}