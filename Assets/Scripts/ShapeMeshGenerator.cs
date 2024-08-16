using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeMeshGenerator : MonoBehaviour
{

    public float extrusionHeight = 1f; // Extrusion depth

    public static ShapeMeshGenerator instance;

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


    public Mesh CreateMeshFromLine(LineRenderer lineRenderer)
    {
        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer is missing.");
            return null;
        }

        int pointCount = lineRenderer.positionCount;
        if (pointCount < 2)
        {
            Debug.LogWarning("Not enough points to create a shape.");
            return null;
        }

        // Create vertices and triangles for the mesh
        Vector3[] vertices = new Vector3[pointCount * 2];
        int[] triangles = new int[(pointCount - 1) * 6];

        // Create the vertices for the top and bottom edges
        for (int i = 0; i < pointCount; i++)
        {
            Vector3 position = lineRenderer.GetPosition(i);

            // Top vertices
            vertices[i] = position;

            // Bottom vertices (extruded)
            vertices[pointCount + i] = position + new Vector3(0, -extrusionHeight, 0);
        }

        // Create triangles for the sides
        for (int i = 0; i < pointCount - 1; i++)
        {
            int topLeft = i;
            int topRight = i + 1;
            int bottomLeft = pointCount + i;
            int bottomRight = pointCount + i + 1;

            // Upper triangle
            triangles[i * 6 + 0] = topLeft;
            triangles[i * 6 + 1] = topRight;
            triangles[i * 6 + 2] = bottomRight;

            // Lower triangle
            triangles[i * 6 + 3] = topLeft;
            triangles[i * 6 + 4] = bottomRight;
            triangles[i * 6 + 5] = bottomLeft;
        }

        // Create the mesh and assign vertices and triangles
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        return mesh;
    }
}
