using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Unlockable : IComparable<Unlockable> {

    public double unlocksAt;
    public GameObject container;
    public bool locked;

    public Unlockable(double unlockPrice, GameObject containerObj, bool isLocked)
    {
        unlocksAt = unlockPrice;
        container = containerObj;
        locked = isLocked;
    }

    public void UnlockMe()
    {
        locked = false;
        container.SetActive(true);
    }

    public void LockMe()
    {
        locked = true;
        container.SetActive(false);
    }

    public bool CheckUnlock(double gameMoney)
    {
        if (gameMoney >= unlocksAt)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Returns difference in score needed to unlock.
    //This is a required method for any Icomparable object
    public int CompareTo(Unlockable other)
    {
        if(other == null)
        {
            return 1;
        }
        return 0;
    }

}
