using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MeshGenerator : MonoBehaviour
{

    void Start()
    {
        CreateCube();
    }

    private void CreateCube()
    {
        var v0 = -0.5f;
        var v1 = 0.5f;
        // 頂点の設定
        // ８点だと法線の計算で影が上手く処理できないので、２４点で設定する
        Vector3[] vertices = {
            new Vector3 (v0, v0, v0), // face front
            new Vector3 (v1, v0, v0),
            new Vector3 (v1, v1, v0),
            new Vector3 (v0, v1, v0),
            new Vector3 (v0, v1, v1), // face back
            new Vector3 (v1, v1, v1),
            new Vector3 (v1, v0, v1),
            new Vector3 (v0, v0, v1),
            new Vector3 (v0, v1, v1), // face top
            new Vector3 (v0, v1, v0),
            new Vector3 (v1, v1, v0),
            new Vector3 (v1, v1, v1),
            new Vector3 (v1, v0, v1), // face bottom
            new Vector3 (v1, v0, v0),
            new Vector3 (v0, v0, v0),
            new Vector3 (v0, v0, v1),
            new Vector3 (v1, v1, v1), // face right
            new Vector3 (v1, v1, v0),
            new Vector3 (v1, v0, v0),
            new Vector3 (v1, v0, v1),
            new Vector3 (v0, v0, v0), // face left
            new Vector3 (v0, v1, v0),
            new Vector3 (v0, v1, v1),
            new Vector3 (v0, v0, v1),
        };
        // 面の設定
        int[] triangles = {
            0, 2, 1, //face front
            0, 3, 2,
            5, 4, 7, //face back
            5, 7, 6,
            8, 10, 9, //face top
            8, 11, 10,
            12, 14, 13, //face bottom
            12, 15, 14,
            16, 18, 17, //face right
            16, 19, 18,
            20, 22, 21, //face left
            20, 23, 22,
        };

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        // mesh.Optimize();
        mesh.RecalculateNormals();
    }
}