using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A Scriptable Object that holds information of a damage

[CreateAssetMenu(fileName = "Damage", menuName = "Damage", order = 0)]
public class Damage : ScriptableObject
{
    public string damageName;
    public string damageDescription;
    public Material color;
}
