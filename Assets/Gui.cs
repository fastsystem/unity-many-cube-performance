using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gui : MonoBehaviour
{
    public GameObject CreateMeshCube;
    public GameObject NormalInstanceCube;
    public GameObject GpuInstanceCube;

    public void OnGUI()
    {
        GUI.color = (this.CreateMeshCube.activeSelf) ? Color.white : Color.black;
        var cmv = GUI.Button(new Rect(Screen.width - 210, 10, 200, 25), "Create Mesh Ver");
        GUI.color = (this.NormalInstanceCube.activeSelf) ? Color.white : Color.black;
        var pv = GUI.Button(new Rect(Screen.width - 210, 40, 200, 25), "Prefab Ver");
        GUI.color = (this.GpuInstanceCube.activeSelf) ? Color.white : Color.black;
        var pgiv = GUI.Button(new Rect(Screen.width - 210, 70, 200, 25), "Prefab(GPU Instancing) Ver");

        if(cmv)
        {
            this.NormalInstanceCube.SetActive(false);
            this.GpuInstanceCube.SetActive(false);
            this.CreateMeshCube.SetActive(true);
        }

        if (pv)
        {
            this.CreateMeshCube.SetActive(false);
            this.GpuInstanceCube.SetActive(false);
            this.NormalInstanceCube.SetActive(true);
        }

        if (pgiv)
        {
            this.CreateMeshCube.SetActive(false);
            this.NormalInstanceCube.SetActive(false);
            this.GpuInstanceCube.SetActive(true);
        }
    }
}
