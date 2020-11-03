using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservePatient : GAction
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("observing");
        return true;
    }
}
