﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalInstanceCube : MonoBehaviour
{
    List<GameObject> cubes = new List<GameObject>();

    public GameObject prefab;

    void OnEnable()
    {
        // 22 x 22 x 22 = 10,648 cube
        int start = Gui.Start;
        int end = Gui.End;

        for (int x = start; x < end; x++)
        {
            for (int y = start; y < end; y++)
            {
                for (int z = start; z < end; z++)
                {
                    var cube = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);
                    cube.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                    cubes.Add(cube);
                }
            }
        }
    }

    void OnDisable()
    {
        foreach(var cube in cubes)
            Destroy(cube);
        cubes.Clear();
    }
}
