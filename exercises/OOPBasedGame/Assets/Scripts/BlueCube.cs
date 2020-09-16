using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCube : Cube
{
    private string curCubeName = "BlueCube";
    private int bluePoint = 3;
    private string color="blue";

    private void Start()
    {
        cubeName = curCubeName;
        cubeColor = color;
    }

    public override void EarnPoint()
    {
        GameManager._instance.AddPoint(bluePoint);
    }

}
