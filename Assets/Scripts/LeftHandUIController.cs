using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeftHandUIController : MonoBehaviour
{
    public GameObject[] LeftHandUIs;
    public static LeftHandUIController instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        /*
        foreach (GameObject LeftHandUI in LeftHandUIs)
        {
            LeftHandUI.SetActive(false);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleUI(GameObject onUI)
    {
        foreach(GameObject LeftHandUI in LeftHandUIs)
        {
            if (LeftHandUI != onUI)
            {
                LeftHandUI.SetActive(false);
            }
            else
            {
                LeftHandUI.SetActive(true);
            }
        }
    }
}
