using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit
{

    protected int damagePower;

    protected int health;

    public int getDamagePower()
    {

        return damagePower;

    }

    public int getHealth()
    {

        return health;

    }

    public virtual void attack()
    {
    }

    public virtual void defend()
    {
    }

    public virtual void repair()
    {
    }

    public virtual void die()
    {
    }
}

