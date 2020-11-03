using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToObserveArea : GAction
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        //GWorld.Instance.GetWorld().ModifyState("PatientWaitingForObserve", 1);
        GWorld.Instance.AddObservePatient(this.gameObject);
        //beliefs.ModifyState("isWaitingForObserve", 1);
        return true;
    }
}
