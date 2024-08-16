using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeletePin : MonoBehaviour
{
    GameObject pin;
    Debugger debugger;
    // Start is called before the first frame update
    void Start()
    {
        Transform parentTransform = GameObject.Find("DebugPanel").transform;
        Transform childTransform = parentTransform.Find("Debugger");
        debugger = childTransform.gameObject.GetComponent<Debugger>();
        if (debugger == null)
        {
            Debug.LogError("Debugger not found");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPin(GameObject pinSelected)
    {
        pin = pinSelected;
        //debugger.AddText("Pin" + pin.GetComponent<DamageType>().damageType.damageName + " Set!");
    }

    public void Delete()
    {
        //debugger.AddText("Pin" + pin.GetComponent<DamageType>().damageType.damageName + " about to be deleted!");
        Destroy(pin);

    }
}
