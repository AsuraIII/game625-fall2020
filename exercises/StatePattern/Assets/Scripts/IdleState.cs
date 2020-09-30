using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private Cube cube;
    public void Enter( Cube cube)
    {
        this.cube = cube;
    }

    public void Do()
    {
        //If can see player change to follow state
        if (CanSeeTarget())
        {
            cube.ChangeState(new FollowState());
        }
    }

    public void Exit()
    {
       
    }

    //If target in range
    private bool CanSeeTarget()
    {
        float distance = (cube.transform.position - cube.target.transform.position).magnitude;
        if (distance <= cube.attractDist)
        {
            Vector3 direction = cube.transform.position - (cube.target.transform.position + Vector3.up);
            Ray ray = new Ray(cube.target.transform.position + Vector3.up, direction);
            Debug.DrawRay(cube.target.transform.position + Vector3.up, direction, Color.red);
            return true;
        }
        return false;
    }
}
