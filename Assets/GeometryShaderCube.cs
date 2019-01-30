using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GeometryShaderCube : MonoBehaviour
{
    public Shader shader;

    List<Vector3> points;
    Material material;
    ComputeBuffer buffer;

    /// <summary>
    /// 初期化
    /// </summary>
    void OnEnable()
    {
        material = new Material(shader);

        // 22 x 22 x 22 = 10,648 cube
        int start = Gui.Start;
        int end = Gui.End;

        points = new List<Vector3>();
        for (int x = start; x < end; x++)
        {
            for (int y = start; y < end; y++)
            {
                for (int z = start; z < end; z++)
                {
                    points.Add(new Vector3(x, y, z));
                }
            }
        }

        buffer = new ComputeBuffer(points.Count, Marshal.SizeOf(typeof(Vector3)), ComputeBufferType.Default);
        buffer.SetData(points);
        material.SetFloat("rotate_x", this.transform.rotation.x);
        material.SetFloat("rotate_y", this.transform.rotation.y);
        material.SetFloat("rotate_z", this.transform.rotation.z);
        material.SetBuffer("points", buffer);
    }

    void OnDisable()
    {
        points.Clear();
        buffer.Release();
    }

    /// <summary>
    /// レンダリング
    /// </summary>
    void OnRenderObject()
    {
        material.SetFloat("rotate_x", this.transform.rotation.x);
        material.SetFloat("rotate_y", this.transform.rotation.y);
        material.SetFloat("rotate_z", this.transform.rotation.z);

        // レンダリングを開始
        material.SetPass(0);

        // 1万個のオブジェクトをレンダリング
        Graphics.DrawProcedural(MeshTopology.Points, points.Count);
    }
}
