using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTreated : GAction
{
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag("Cubicle");
        if (target == null)
            return false;
        return true;
    }

    public override bool PostPerform()
    { 
        GWorld.Instance.GetWorld().ModifyState("Treated", 1);
        beliefs.ModifyState("isCured", 1);
        inventory.RemoveItem(target);
        DialogueManager.scc.setGameStateValue("Action", "equals", "Finish Treating");
        UI_Dialogue._instance.SetDialogue("Nurse: " + DialogueManager.scc.getSCCLine("Nurse"));
        DialogueManager.scc.setGameStateValue("Action", "equals", "Get Treated");
        UI_Dialogue._instance.SetDialogue("Patient: " + DialogueManager.scc.getSCCLine("Patient"));
        return true;
    }
}
