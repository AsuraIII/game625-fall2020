using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeState : IState
{
    private Cube cube;
    public void Enter(Cube cube)
    {
        this.cube = cube;
    }
    public void Do()
    {
        EvadeFromTarget();
    }

    public void Exit()
    {
        
    }

    private void EvadeFromTarget()
    {

        cube.transform.position = Vector3.MoveTowards(cube.transform.position, cube.spawnPosition, Time.deltaTime * cube.Speed);
        float distance = Vector3.Distance(cube.SpawnPosition, cube.transform.position);
        if (distance <= 0.0f)
        {
            cube.ChangeState(new IdleState());
        }
    }
}
