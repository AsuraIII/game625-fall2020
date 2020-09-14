using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public virtual void SetColor() {
        //this.GetComponent<Renderer>().material.color = Color.white;
    }

    private void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            SetColor();
        }
    }
    
}
