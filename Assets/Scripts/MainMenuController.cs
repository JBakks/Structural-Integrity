using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    // The transform of the object to rotate around. Currently set to self in inspector.
    public Transform target;
    // The rotation speed
    public float rotationSpeed = 5f;
    // The distance from the target
    [SerializeField]
    private float distance = 2f;

    // Update is called once per frame
    void Update()
    {
        // Rotates the game object that this script is attached to around target
        if (target != null)
        {
            // Get the target's forward direction
            Vector3 targetForward = target.forward;

            // Calculate the new position based on the target's position, forward direction, and distance
            Vector3 newPosition = target.position + (targetForward * distance);

            // Set the GameObject's position to the new position
            transform.position = newPosition;
            transform.LookAt(target);
            transform.Rotate(Vector3.up, -180);
            //transform.RotateAround(target.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
