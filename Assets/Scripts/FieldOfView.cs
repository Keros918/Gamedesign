using System;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] Transform player;
    private Mesh mesh;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    void LateUpdate() {
        float fov = 360f;
        Vector3 origin = player.position;
        int rayCount = 360;
        float angle = 0f;
        float angleIncrease = fov / rayCount;
        float viewDistance = 10f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            Vector3 vectorFromAngle = GetVectorFromAngle(angle);
            RaycastHit2D hit = Physics2D.Raycast(origin, vectorFromAngle, viewDistance, layerMask);
            
            if (hit.collider == null)
            {
                vertex = origin + vectorFromAngle * viewDistance;
            }
            else
            {
                vertex = hit.point;
            }
            
            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
                
                triangleIndex += 3;
            }
            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    private Vector3 GetVectorFromAngle(float angle)
    {
        float angleRed = (float)(angle * (Math.PI/180f));
        return new Vector3(Mathf.Cos(angleRed), Mathf.Sin(angleRed));
    }

    // public void SetOrigin(Vector3 origin)
    // {
    //     this.origin = origin;
    // }
}
