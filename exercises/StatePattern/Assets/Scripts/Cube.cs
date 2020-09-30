using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject target;
    public float attractDist = 5.0f;
    private float speed = 2.0f;

    public Vector3 spawnPosition;

    public Vector3 SpawnPosition { get => spawnPosition; set => spawnPosition = value; }
    public float Speed { get => speed; set => speed = value; }

    private IState currentState;

    private void Awake()
    {
        ChangeState(new IdleState());    
    }

    private void Start()
    {
        spawnPosition = this.transform.position;
        target = FindObjectOfType<PlayerController>().gameObject;
    }

    private void Update()
    {
        currentState.Do();
    }



    //Change State
    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter(this);
    }

}
