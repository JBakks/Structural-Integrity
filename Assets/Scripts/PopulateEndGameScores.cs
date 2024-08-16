using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateEndGameScores : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject cracks = FindObjectByName("Cracks");
        GameObject spalls = FindObjectByName("Spalls");
        GameObject pittings = FindObjectByName("Pittings");
        GameObject concrete_joints = FindObjectByName("Concrete Joints");

        if (cracks != null)
        {
            PlayerPrefs.SetInt("CCracks", cracks.transform.childCount);
        }
        else
        {
            PlayerPrefs.SetInt("CCracks", 0);
        }

        if (spalls != null)
        {
            PlayerPrefs.SetInt("CSpalls", spalls.transform.childCount);
        }
        else
        {
            PlayerPrefs.SetInt("CSpalls", 0);
        }

        if (pittings != null)
        {
            PlayerPrefs.SetInt("CPittings", pittings.transform.childCount);
        }
        else
        {
            PlayerPrefs.SetInt("CPittings", 0);
        }

        if (concrete_joints != null)
        {
            PlayerPrefs.SetInt("CConcrete Joints", concrete_joints.transform.childCount);
        }
        else
        {
            PlayerPrefs.SetInt("CConcrete Joints", 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
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
}
