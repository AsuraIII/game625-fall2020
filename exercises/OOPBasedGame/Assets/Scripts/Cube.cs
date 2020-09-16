using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cube :MonoBehaviour
{
    public string cubeName = "cubeName";
    public int cubePoint;
    public string cubeColor;
    public abstract void EarnPoint();

    public static event Action OnCubeCollectedSound;
    public static event Action<Cube> OnCubeCollectedRepository;

    //public void AddToCubeList() {
    //    GameStatus._instance.AddCube(this.gameObject);
    //}
    private void Start()
    {
       
    }
    public void DestroyCube()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //act event
            if (OnCubeCollectedSound != null)
            {
                OnCubeCollectedSound();
            }
            if (OnCubeCollectedRepository != null) {
                OnCubeCollectedRepository(this);
            }

            this.EarnPoint();
            this.DestroyCube();

            
        }
    }
}
