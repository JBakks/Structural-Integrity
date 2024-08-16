using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowDamage : MonoBehaviour
{
    public TMP_Text damageInfo;

    Damage hoveredDamage;

    public Debugger debugger;
    // Start is called before the first frame update
    void Start()
    {
        //damageInfo = GetComponent<TMP_Text>();
        damageInfo.text = "\nDamage: ---\nDamage Description: ---";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Populates the damage info canvas for the appropriate damage
    public void PopulateCanvas(DamageType damage)
    {
        debugger.AddText("Entered Populate Canavs");
        if (damage != null && damage.damageType != null)
        {
            debugger.AddText("Damage exists for canvas population");
            hoveredDamage = damage.damageType;
            damageInfo.text = "\nDamage: " + hoveredDamage.damageName + "\nDamage Description: " + hoveredDamage.damageDescription;
            debugger.AddText("canvas populated with damage info");
        }
        else
        {
            debugger.AddText("Damage doesn't exist");
            damageInfo.text = "\nDamage: ---\nDamage Description: ---";
            debugger.AddText("canvas populated with empty damage");
        }
        
    }

    public string GetText()
    {
        return damageInfo.text;
    }
}
