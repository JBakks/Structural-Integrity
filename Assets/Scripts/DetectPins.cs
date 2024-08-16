using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPins : MonoBehaviour
{
    Damage bridgeDamage;

    bool damageChosen;

    public Debugger debugger;

    // Start is called before the first frame update
    void Start()
    {
        bridgeDamage = GetComponent<DamageType>().damageType;
        damageChosen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!damageChosen && other.tag == "pin")
        {
            //debugger.AddText("Trigger detected!\n");
            Damage pinDamage = other.gameObject.GetComponent<DamageType>().damageType;
            debugger.AddText("Pin Damage: " + pinDamage.damageName + " Bridge Damage: " + bridgeDamage.damageName);
            if (bridgeDamage.damageName.Equals(pinDamage.damageName))
            {
                debugger.AddText("Pin damage is the same as bridge damage");
                Score.instance.IncreaseScore(pinDamage);
                debugger.AddText("Increased score and is now: " + Score.instance.GetScore(pinDamage));
                damageChosen = !damageChosen;
                GetComponent<MeshRenderer>().enabled = true;
            }
        }
        
    }
}
