using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using Oculus.Interaction.Input;

public class ShapeDrawer : MonoBehaviour
{
    public GameObject trailPrefab;  // A prefab representing the trail
    private bool isDrawing = false; // Whether the user is currently drawing
    private GameObject currentTrail; // The current trail GameObject being created
    private LineRenderer lineRenderer; // Line renderer for drawing the shape
    public RayInteractor rRayInteractor;
    public GameObject customShapedObject;
    public Debugger debugger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.A))
        {
            if (!isDrawing)
            {
                if (Physics.Raycast(rRayInteractor.Ray, out RaycastHit hitInfo, rRayInteractor.MaxRayLength))
                {
                    //debugger.AddText("\nRay Casted");
                    if (hitInfo.collider.tag == "ground")
                    {
                        StartDrawing(hitInfo.point);
                    }
                }
            }
            else
            {
                if (Physics.Raycast(rRayInteractor.Ray, out RaycastHit hitInfo, rRayInteractor.MaxRayLength))
                {
                    //debugger.AddText("\nRay Casted");
                    if (hitInfo.collider.tag == "ground")
                    {
                        ContinueDrawing(hitInfo.point); // Add points to the line renderer
                    }
                }
            }
        }
        else
        {
            if (isDrawing)
            {
                StopDrawing(); // When the trigger is released
            }
        }
    }

    private void StartDrawing(Vector3 hitPoint)
    {
        isDrawing = true;

        // Instantiate a new trail prefab when starting to draw
        currentTrail = Instantiate(trailPrefab, hitPoint, Quaternion.LookRotation(Vector3.up));
        lineRenderer = currentTrail.GetComponent<LineRenderer>();

        if (lineRenderer == null)
        {
            Debug.LogError("No LineRenderer component found in the trail prefab.");
        }

        // Initialize the line renderer with a single point
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, hitPoint);
    }

    private void ContinueDrawing(Vector3 hitPoint)
    {
        if (lineRenderer != null)
        {
            // Increase the number of positions and add the current controller position
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, hitPoint);
        }
    }

    private void StopDrawing()
    {
        isDrawing = false;
        // Creates a game object using the line renderer
        Mesh mesh = ShapeMeshGenerator.instance.CreateMeshFromLine(lineRenderer);
        if (mesh != null)
        {
            debugger.AddText("Mesh Created");
            customShapedObject.GetComponent<MeshFilter>().mesh = mesh;
        }
        else
        {
            debugger.AddText("Mesh is null");
        }
        
    }
}
