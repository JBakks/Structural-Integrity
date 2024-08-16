using UnityEngine;

public class SkyManager : MonoBehaviour
{
    public Material skyboxMaterial; // Assign this material in the Inspector
    public float skySpeed;

    void Start()
    {
        // Assign the skybox material at the start of the game
        if (skyboxMaterial != null)
        {
            RenderSettings.skybox = skyboxMaterial;
        }
        else
        {
            Debug.LogError("Skybox material has not been assigned in the Inspector");
        }
    }

    void Update()
    {
        // Ensure that the skybox material has been assigned
        if (RenderSettings.skybox != null)
        {
            RenderSettings.skybox.SetFloat("_Rotation", Time.time * skySpeed);
        }
    }
}
