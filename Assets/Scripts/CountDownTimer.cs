using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float startTimeInSeconds = 60f; // Total time for the timer (in seconds)
    private float timeRemaining; // The time left in the countdown
    private bool isRunning = false; // Is the timer currently running

    private Damage[] damages;

    public static CountdownTimer instance;
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
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                isRunning = false;
                foreach (Damage damage in damages)
                {
                    PlayerPrefs.SetInt(damage.name, Score.instance.GetScore(damage));
                }
                SceneManager.LoadScene("EndGame");
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

    // Reset the timer to the initial start time
    public void ResetTimer()
    {
        timeRemaining = startTimeInSeconds;
        isRunning = false;
    }

    // Get the remaining time as a formatted string (MM:SS)
    public string GetFormattedTime()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds); // Format as MM:SS
    }

    // Check if the timer is running
    public bool IsRunning()
    {
        return isRunning;
    }

    // Get the raw time remaining in seconds
    public float GetTimeRemaining()
    {
        return timeRemaining;
    }
}
