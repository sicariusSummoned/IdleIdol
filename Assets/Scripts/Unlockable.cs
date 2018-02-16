using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Unlockable : IComparable<Unlockable> {

    public double unlocksAt;
    public GameObject container;
    public bool locked;
    public string prefString;

    public Unlockable(string prefName ,double unlockPrice, GameObject containerObj, bool isLocked)
    {
        unlocksAt = unlockPrice;
        container = containerObj;
        locked = isLocked;
        prefString = prefName;

    }

    public void UnlockMe()
    {
        locked = false;
        container.SetActive(true);
        PlayerPrefs.SetInt(prefString, 1);

        Debug.Log("unlocking:" + prefString);

    }

    public void LockMe()
    {
        locked = true;
        container.SetActive(false);
        PlayerPrefs.SetInt(prefString, 0);

        Debug.Log("locking:" + prefString);


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
