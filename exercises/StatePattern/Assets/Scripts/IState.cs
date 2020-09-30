using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void Enter(Cube cube);

    void Do();

    void Exit();
}
