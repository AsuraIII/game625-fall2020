using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    //Enter State
    void Enter(Cube cube);

    //On State
    void Do();

    //Exit State
    void Exit();
}
