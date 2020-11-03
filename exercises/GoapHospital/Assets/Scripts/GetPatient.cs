using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GetPatient : GAction
{
    GameObject resource;
    public override bool PrePerform()
    {
        target = GWorld.Instance.RemovePatient();
        if (target == null)
        {
            return false;
        }

        resource = GWorld.Instance.RemoveCubicle();
        if (resource != null)
        {
            inventory.AddItem(resource);
        }
        else
        {
            GWorld.Instance.AddPatient(target);
            target = null;
            return false;
        }

        GWorld.Instance.GetWorld().ModifyState("FreeCubicle", -1);
        return true;
    }

    public override bool PostPerform()
    {
        DialogueManager.scc.setGameStateValue("Action", "equals", "Get Patient");
        UI_Dialogue._instance.SetDialogue("Nurse: " + DialogueManager.scc.getSCCLine("Nurse"));
        GWorld.Instance.GetWorld().ModifyState("PatientWaiting", -1);
        if (target)
            target.GetComponent<GAgent>().inventory.AddItem(resource);
        return true;
    }
}
