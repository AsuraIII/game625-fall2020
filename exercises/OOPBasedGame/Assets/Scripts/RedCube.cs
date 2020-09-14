using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RedCube : Cube
{
    public string curCubeName = "RedCube";
    private int redPoint = 1;

    private void Start()
    {
        cubeName = curCubeName;
    }


    public override void EarnPoint()
    {
        GameManager._instance.AddPoint(redPoint);
    }

}
