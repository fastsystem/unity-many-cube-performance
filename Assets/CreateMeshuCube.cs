using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class CreateMeshuCube : MonoBehaviour
{

    void OnEnable()
    {
        var v0 = -0.4f;
        var v1 = 0.4f;

        // 22 x 22 x 22 = 10,648 cube
        int start = -11;
        int end = 22 + start;

        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        for (int x = start; x < end; x++)
        {
            for (int y = start; y < end; y++)
            {
                for (int z = start; z < end; z++)
                {
                    int triangleOffset = vertices.Count;
                    // 頂点の設定
                    // ８点だと法線の計算で影が上手く処理できないので、２４点で設定する
                    vertices.AddRange(new Vector3[] {
                        new Vector3 (x + v0, y + v0, z + v0), // face front
                        new Vector3 (x + v1, y + v0, z + v0),
                        new Vector3 (x + v1, y + v1, z + v0),
                        new Vector3 (x + v0, y + v1, z + v0),
                        new Vector3 (x + v0, y + v1, z + v1), // face back
                        new Vector3 (x + v1, y + v1, z + v1),
                        new Vector3 (x + v1, y + v0, z + v1),
                        new Vector3 (x + v0, y + v0, z + v1),
                        new Vector3 (x + v0, y + v1, z + v1), // face top
                        new Vector3 (x + v0, y + v1, z + v0),
                        new Vector3 (x + v1, y + v1, z + v0),
                        new Vector3 (x + v1, y + v1, z + v1),
                        new Vector3 (x + v1, y + v0, z + v1), // face bottom
                        new Vector3 (x + v1, y + v0, z + v0),
                        new Vector3 (x + v0, y + v0, z + v0),
                        new Vector3 (x + v0, y + v0, z + v1),
                        new Vector3 (x + v1, y + v1, z + v1), // face right
                        new Vector3 (x + v1, y + v1, z + v0),
                        new Vector3 (x + v1, y + v0, z + v0),
                        new Vector3 (x + v1, y + v0, z + v1),
                        new Vector3 (x + v0, y + v0, z + v0), // face left
                        new Vector3 (x + v0, y + v1, z + v0),
                        new Vector3 (x + v0, y + v1, z + v1),
                        new Vector3 (x + v0, y + v0, z + v1),
                    });
                    // 面の設定
                    triangles.AddRange(new int[] {
                        triangleOffset + 0, triangleOffset + 2, triangleOffset + 1, //face front
                        triangleOffset + 0, triangleOffset + 3, triangleOffset + 2,
                        triangleOffset + 5, triangleOffset + 4, triangleOffset + 7, //face back
                        triangleOffset + 5, triangleOffset + 7, triangleOffset + 6,
                        triangleOffset + 8, triangleOffset + 10, triangleOffset + 9, //face top
                        triangleOffset + 8, triangleOffset + 11, triangleOffset + 10,
                        triangleOffset + 12, triangleOffset + 14, triangleOffset + 13, //face bottom
                        triangleOffset + 12, triangleOffset + 15, triangleOffset + 14,
                        triangleOffset + 16, triangleOffset + 18, triangleOffset + 17, //face right
                        triangleOffset + 16, triangleOffset + 19, triangleOffset + 18,
                        triangleOffset + 20, triangleOffset + 22, triangleOffset + 21, //face left
                        triangleOffset + 20, triangleOffset + 23, triangleOffset + 22,
                    });
                }
            }
        }

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        // mesh.Optimize();
        mesh.RecalculateNormals();
    }

    void OnDisable()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();
    }
}