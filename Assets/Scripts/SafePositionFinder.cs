using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Finds a safe position where a game object can be located at without colliding with other game objects
// Used right now for UI elements to not be obstructed by other objects in the scene
public class SafePositionFinder : MonoBehaviour
{
    private float radius = 1f; // Radius for new position generation
    private float checkRadius = 0.5f; // Radius for collision checks
    private float maxAttempts = 100; // Maximum attempts to find a safe position
    public Debugger debugger;
    public GameObject player;

    private void OnEnable()
    {
        if (gameObject != null)
        {
            Vector3 originalPosition = transform.position;
            Vector3 safePosition = FindSafePosition(originalPosition);

            if (safePosition != Vector3.zero) // Found a safe position
            {
                //debugger.AddText("Changed Position: " + safePosition + " Original Position: " + originalPosition);
                transform.position = safePosition;
                transform.LookAt(player.transform);
                transform.Rotate(Vector3.up, -180);
            }
            else
            {
                //debugger.AddText("Unable to find a safe position");
            }

            gameObject.SetActive(true);
        }
    }

    // Find a safe position by checking for collisions
    private Vector3 FindSafePosition(Vector3 start)
    {
        Vector3 currentPosition = start;

        for (int i = 0; i < maxAttempts; i++)
        {
            // Check if there's any collision at the current position
            bool hasCollision = Physics.CheckSphere(currentPosition, checkRadius, Physics.AllLayers);

            if (!hasCollision)
            {
                return currentPosition;
            }

            // Get a new valid position randomly
            currentPosition = GenerateRandomPointInsideSphere(start);
            //currentPosition = GenerateRandomPointOnSphereSurface(start);
            
        }

        // If no safe position found after max attempts, return zero vector
        return Vector3.zero;
    }

    public Vector3 GenerateRandomPointInsideSphere(Vector3 sphereCenter)
    {
        while (true)
        {
            // Generate a random point within a range [-radius, radius)
            float randomX = Random.Range(-radius, radius);
            float randomY = Random.Range(-radius, radius);
            float randomZ = Random.Range(-radius, radius);

            // Offset these values by the sphere's center
            Vector3 randomPoint = sphereCenter + new Vector3(randomX, randomY, randomZ);

            // Check if the generated point is within the sphere
            if (Vector3.SqrMagnitude(randomPoint - sphereCenter) <= radius * radius)
            {
                //debugger.AddText("New Location: " + randomPoint);
                return randomPoint; // If inside the sphere, return this point
            }
        }
    }

    public Vector3 GenerateRandomPointOnSphereSurface(Vector3 sphereCenter)
    {
        // Generate random angles for theta and phi
        float theta = Random.Range(0f, 2f * Mathf.PI); // 0 to 2π
        float phi = Random.Range(0f, Mathf.PI); // 0 to π

        // Convert spherical coordinates to Cartesian coordinates
        float x = radius * Mathf.Sin(phi) * Mathf.Cos(theta);
        float y = radius * Mathf.Sin(phi) * Mathf.Sin(theta);
        float z = radius * Mathf.Cos(phi);

        // Offset by the sphere's center
        Vector3 pointOnSphere = sphereCenter + new Vector3(x, y, z);

        return pointOnSphere;
    }
}
