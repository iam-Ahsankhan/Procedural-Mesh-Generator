using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class MeshGenerator : MonoBehaviour
{
    public enum ShapeType { Cube, Plane, Sphere }
    public ShapeType shape = ShapeType.Cube;

    [Header("General Settings")]
    public float size = 1f;
    [Range(2, 50)] public int resolution = 10;

    private Mesh mesh;

    void OnValidate()
    {
        GenerateMesh();
    }

    void GenerateMesh()
    {
        if (mesh == null)
        {
            mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;
        }

        mesh.Clear();

        switch (shape)
        {
            case ShapeType.Cube:
                GenerateCube();
                break;
            case ShapeType.Plane:
                GeneratePlane();
                break;
            case ShapeType.Sphere:
                GenerateSphere();
                break;
        }

        mesh.RecalculateNormals();
    }

    void GenerateCube()
    {
        mesh.vertices = new Vector3[]
        {
            new Vector3(-size, -size, size),  // Front bottom left
            new Vector3(size, -size, size),   // Front bottom right
            new Vector3(size, size, size),    // Front top right
            new Vector3(-size, size, size),   // Front top left

            new Vector3(-size, -size, -size), // Back bottom left
            new Vector3(size, -size, -size),  // Back bottom right
            new Vector3(size, size, -size),   // Back top right
            new Vector3(-size, size, -size)   // Back top left
        };

        mesh.triangles = new int[]
        {
            // Front
            0, 2, 1, 0, 3, 2,
            // Back
            5, 6, 4, 4, 6, 7,
            // Left
            4, 7, 0, 0, 7, 3,
            // Right
            1, 2, 5, 5, 2, 6,
            // Top
            3, 7, 2, 2, 7, 6,
            // Bottom
            4, 0, 5, 5, 0, 1
        };
    }

    void GeneratePlane()
    {
        int verts = resolution * resolution;
        Vector3[] vertices = new Vector3[verts];
        int[] triangles = new int[(resolution - 1) * (resolution - 1) * 6];

        for (int y = 0; y < resolution; y++)
        {
            for (int x = 0; x < resolution; x++)
            {
                vertices[y * resolution + x] =
                    new Vector3((float)x / (resolution - 1) * size, 0, (float)y / (resolution - 1) * size);
            }
        }

        int index = 0;
        for (int y = 0; y < resolution - 1; y++)
        {
            for (int x = 0; x < resolution - 1; x++)
            {
                int i = y * resolution + x;
                triangles[index++] = i;
                triangles[index++] = i + resolution;
                triangles[index++] = i + 1;
                triangles[index++] = i + 1;
                triangles[index++] = i + resolution;
                triangles[index++] = i + resolution + 1;
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }

    void GenerateSphere()
    {
        int latSegments = resolution;
        int lonSegments = resolution;

        Vector3[] vertices = new Vector3[(latSegments + 1) * (lonSegments + 1)];
        int[] triangles = new int[latSegments * lonSegments * 6];

        int vertIndex = 0;
        int triIndex = 0;

        for (int lat = 0; lat <= latSegments; lat++)
        {
            float a1 = Mathf.PI * lat / latSegments;
            float sin1 = Mathf.Sin(a1);
            float cos1 = Mathf.Cos(a1);

            for (int lon = 0; lon <= lonSegments; lon++)
            {
                float a2 = 2 * Mathf.PI * lon / lonSegments;
                float sin2 = Mathf.Sin(a2);
                float cos2 = Mathf.Cos(a2);

                vertices[vertIndex++] = new Vector3(sin1 * cos2, cos1, sin1 * sin2) * size;
            }
        }

        vertIndex = 0;
        for (int lat = 0; lat < latSegments; lat++)
        {
            for (int lon = 0; lon < lonSegments; lon++)
            {
                int current = lat * (lonSegments + 1) + lon;
                int next = current + lonSegments + 1;

                triangles[triIndex++] = current;
                triangles[triIndex++] = next;
                triangles[triIndex++] = current + 1;

                triangles[triIndex++] = current + 1;
                triangles[triIndex++] = next;
                triangles[triIndex++] = next + 1;
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }

}
