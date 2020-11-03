using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Nurse : GAgent
{

    public override void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("treatPatient", 1, false);
        goals.Add(s1, 3);

        SubGoal s2 = new SubGoal("rested", 1, false);
        goals.Add(s2, 1);

        SubGoal s3 = new SubGoal("observedPatient", 1, false);
        goals.Add(s3, 1);

        Invoke("GetTired", Random.Range(10, 20));
        Invoke("ObservePatient", Random.Range(50, 60));
    }

    void GetTired()
    {
        beliefs.ModifyState("exhausted", 0);
        Invoke("GetTired", Random.Range(10, 20));
    }

    void ObservePatient()
    {
        if (GWorld.Instance.GetNumObservePatient() >= 0)
        {
            beliefs.ModifyState("observing", 0);
            Invoke("ObservePatient", Random.Range(50, 60));
        }
    }

}
