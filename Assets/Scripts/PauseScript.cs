using System.Collections;
using UnityEngine;
using Oculus.Interaction.Input;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseCanvas;
    bool pause = false;

    // Coroutine reference
    Coroutine toggleCoroutine;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.Start))
        {
            // Check if coroutine is running before starting another instance
            if (toggleCoroutine == null)
                toggleCoroutine = StartCoroutine(TogglePauseCanvas());
        }
    }

    IEnumerator TogglePauseCanvas()
    {
        // Toggle pause state
        pause = !pause;

        if (pause)
        {
            Time.timeScale = 0;
            // Pause to prevent rapid toggling
            yield return new WaitForSecondsRealtime(0.2f);
            pauseCanvas.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            // Pause to prevent rapid toggling
            yield return new WaitForSecondsRealtime(0.2f);
            pauseCanvas.SetActive(false);
        }

        // Reset coroutine reference
        toggleCoroutine = null;
    }
}
