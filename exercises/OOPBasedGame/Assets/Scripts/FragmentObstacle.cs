using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentObstacle : Obstacle
{
    private float rotateSpeed = 50.0f;
    public void Movement()
    {
        this.transform.Rotate(Vector3.left, rotateSpeed * Time.deltaTime);
    }

    public override void SetColor()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }

    private void Update()
    {
        Movement();
    }

}
