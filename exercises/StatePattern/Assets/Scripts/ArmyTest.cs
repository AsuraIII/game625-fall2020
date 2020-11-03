using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedArmy : Unit
{
    public override void attack()
    {
        Debug.Log("RedArmy Attack");
    }
    public override void defend()
    {
        Debug.Log("RedArmy Defend");
    }
    public override void repair()
    {
        Debug.Log("RedArmy Repair");
    }
    public override void die()
    {
        Debug.Log("RedArmy Die");
    }
}

public class BlueArmy : Unit
{
    public override void attack()
    {
        Debug.Log("BlueArmy Attack");
    }
    public override void defend()
    {
        Debug.Log("BlueArmy Defend");
    }
    public override void repair()
    {
        Debug.Log("BlueArmy Repair");
    }
    public override void die()
    {
        Debug.Log("BlueArmy Die");
    }
}
public class ArmyTest:MonoBehaviour
{
    private void Start()
    {
        RedArmy r = new RedArmy();
        BlueArmy b = new BlueArmy();
        b.attack();
        r.attack();
    }

}
