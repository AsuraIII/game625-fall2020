using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCube : Cube
{
    private string curCubeName = "BlueCube";
    private int bluePoint = 3;

    private void Start()
    {
        cubeName = curCubeName;
    }

    public override void EarnPoint()
    {
        GameManager._instance.AddPoint(bluePoint);
    }

}
