using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : IState
{
    private Cube cube;
    public void Enter(Cube cube)
    {
        this.cube = cube;
    }


    public void Do()
    {
        if (AwayFromTarget())
        {
            cube.ChangeState(new EvadeState());
        }
        else
        {
            MoveToTarget();
        }

    }

    public void Exit()
    {

    }

    //Check if away from target
    private bool AwayFromTarget()
    {
        //distance between target and cube
        float distance = (cube.transform.position - cube.target.transform.position).magnitude;
        if (distance > cube.attractDist)
        {
            return true;
        }
        return false;
    }

    //Move cube to target
    private void MoveToTarget()
    {
        cube.transform.position = Vector3.MoveTowards(cube.transform.position, cube.target.transform.position, Time.deltaTime * cube.Speed);
    }
}
