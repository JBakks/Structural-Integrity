using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopulateCurvedCanvas : MonoBehaviour
{
    public TMP_Dropdown damageDropdown;

    List<string> damageDropdownOptions;

    private Damage[] damages;

    private void Start()
    {
        damages = Resources.LoadAll<Damage>("Damage");
        damageDropdownOptions = new List<string>();
        damageDropdown.ClearOptions();
        Populate();
    }

    //Populates the damage selection canvas with all the available damages from the resources folder
    public void Populate()
    {
        foreach (Damage damage in damages)
        {
            damageDropdownOptions.Add(damage.damageName);
        }
        damageDropdown.AddOptions(damageDropdownOptions);
    }


}
