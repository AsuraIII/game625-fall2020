using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCube : Cube
{
    public string curCubeName = "GreenCube";
    private int greenPoint = 2;
    private string color="green";

    private void Start()
    {
        cubeName = curCubeName;
        cubeColor = color;
    }

    public override void EarnPoint()
    {
        GameManager._instance.AddPoint(greenPoint);
    }
}
