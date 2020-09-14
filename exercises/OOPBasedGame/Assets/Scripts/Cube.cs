using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cube :MonoBehaviour
{
    public string cubeName = "cubeName";
    public abstract void EarnPoint();

    //public void AddToCubeList() {
    //    GameStatus._instance.AddCube(this.gameObject);
    //}

    public void DestroyCube()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.EarnPoint();
            GameManager._instance.AddCube(this);
            this.DestroyCube();
        }
    }
}
