﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gui : MonoBehaviour
{
    public GameObject CreateMeshCube;
    public GameObject NormalInstanceCube;
    public GameObject GpuInstanceCube;
    public GameObject GeometryShaderCube;

    // 22 x 22 x 22 = 10,648 cube
    internal static int Start = -11;
    internal static int End = 22 - 11;

    public void OnGUI()
    {
        GUI.color = (this.CreateMeshCube.activeSelf) ? Color.white : Color.black;
        var cmv = GUI.Button(new Rect(10, 10 + 30, 200, 25), "Create Mesh Ver");
        GUI.color = (this.NormalInstanceCube.activeSelf) ? Color.white : Color.black;
        var pv = GUI.Button(new Rect(10, 40 + 30, 200, 25), "Prefab Ver");
        GUI.color = (this.GpuInstanceCube.activeSelf) ? Color.white : Color.black;
        var pgiv = GUI.Button(new Rect(10, 70 + 30, 200, 25), "Prefab(GPU Instancing) Ver");
        GUI.color = (this.GeometryShaderCube.activeSelf) ? Color.white : Color.black;
        var gsc = GUI.Button(new Rect(10, 100 + 30, 200, 25), "Geometry Shader Ver");

        if (cmv)
        {
            this.NormalInstanceCube.SetActive(false);
            this.GpuInstanceCube.SetActive(false);
            this.GeometryShaderCube.SetActive(false);
            this.CreateMeshCube.SetActive(true);
        }

        if (pv)
        {
            this.CreateMeshCube.SetActive(false);
            this.GpuInstanceCube.SetActive(false);
            this.GeometryShaderCube.SetActive(false);
            this.NormalInstanceCube.SetActive(true);
        }

        if (pgiv)
        {
            this.CreateMeshCube.SetActive(false);
            this.NormalInstanceCube.SetActive(false);
            this.GeometryShaderCube.SetActive(false);
            this.GpuInstanceCube.SetActive(true);
        }

        if (gsc)
        {
            this.CreateMeshCube.SetActive(false);
            this.NormalInstanceCube.SetActive(false);
            this.GpuInstanceCube.SetActive(false);
            this.GeometryShaderCube.SetActive(true);
        }
    }
}
