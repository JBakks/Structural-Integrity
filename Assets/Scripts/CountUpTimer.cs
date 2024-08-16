using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountUpTimer : MonoBehaviour
{
    public float maxTimeInSeconds = 10f; // Maximum time for the timer (in seconds)
    private float timeElapsed; // The time elapsed since the timer started
    private bool isRunning = false; // Is the timer currently running

    private Damage[] damages;

    public static CountUpTimer instance;

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

    // Initialize the timer
    void Start()
    {
        damages = Resources.LoadAll<Damage>("Damage");
        ResetTimer();
        StartTimer();
    }

    // Update the timer if it's running
    void Update()
    {
        if (isRunning)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= maxTimeInSeconds)
            {
                EndGame();
            }
        }
    }

    // Start the timer
    public void StartTimer()
    {
        isRunning = true;
    }

    // Stop the timer
    public void StopTimer()
    {
        isRunning = false;
    }

    // Reset the timer to start counting from zero
    public void ResetTimer()
    {
        timeElapsed = 0f;
        isRunning = false;
    }

    // Get the elapsed time as a formatted string (MM:SS)
    public string GetFormattedTime()
    {
        if (instance == null)
        {
            instance = this;
        }
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds); // Format as MM:SS
    }

    // Check if the timer is running
    public bool IsRunning()
    {
        return isRunning;
    }

    // Get the raw time elapsed in seconds
    public float GetTimeElapsed()
    {
        return timeElapsed;
    }

    // Get the maximum time allowed for the timer
    public float GetMaxTime()
    {
        return maxTimeInSeconds;
    }

    // Method to end the game early
    public void EndGame()
    {
        isRunning = false;
        foreach (Damage damage in damages)
        {
            PlayerPrefs.SetInt(damage.name, Score.instance.GetScore(damage));
        }
        SceneManager.LoadScene("EndGame");
    }
}
