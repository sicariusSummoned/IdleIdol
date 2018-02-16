using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockManager : MonoBehaviour {

    public GameObject micAmp;
    public GameObject autoTuner;
    public GameObject tallerShoes;
    public GameObject holograms;
    public GameObject recording;
    public GameObject bodyDouble;

    public GameObject smile;
    public GameObject vlogging;
    public GameObject glowsticks;
    public GameObject pyrotechnics;
    public GameObject fans;
    public GameObject merchandising;
    public GameObject glitter;

    private List<Unlockable> unlockables;

    protected GameManagerScript GameManager;

    // Use this for initialization
    void Start () {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        unlockables = new List<Unlockable>();


        //On game start, make sure that all the stuff we unlocked last time stays unlocked. 

        Initialize();
        PreGameCheck();

        InvokeRepeating("CheckAll", 0.25f, 0.25f);

    }

    void CheckAll()
    {
        for (int i = 0; i < unlockables.Count; i++)
        {
            if (unlockables[i].locked)
            {
                if (unlockables[i].CheckUnlock(GameManager.PlayerScore))
                {
                    unlockables[i].UnlockMe();
                }
            }

        }
    }

    //Reactivate all things you've already unlocked
    void PreGameCheck()
    {
        for(int i = 0; i < unlockables.Count; i++)
        {
            //1 means unlocked, 0 means locked
            if(PlayerPrefs.GetInt(unlockables[i].prefString) == 1)
            {
                unlockables[i].UnlockMe();
            }
        }
    }




    void Initialize()
    {

        unlockables.Add(new Unlockable("micAmpFlag",50, micAmp, true));
        unlockables.Add(new Unlockable("autoTunerFlag",250, autoTuner, true));
        unlockables.Add(new Unlockable("tallerShoesFlag",500, tallerShoes, true));
        unlockables.Add(new Unlockable("hologramsFlag",15000, holograms, true));
        unlockables.Add(new Unlockable("recordingFlag",50000, recording, true));
        unlockables.Add(new Unlockable("bodyDoubleFlag",250000, bodyDouble, true));

        unlockables.Add(new Unlockable("smileFlag",100, smile, true));
        unlockables.Add(new Unlockable("vloggingFlag",1000, vlogging, true));
        unlockables.Add(new Unlockable("glowsticksFlag",500, glowsticks, true));
        unlockables.Add(new Unlockable("pyrotechnicsFlag",10000, pyrotechnics, true));
        unlockables.Add(new Unlockable("fansFlag",10000, fans, true));
        unlockables.Add(new Unlockable("merchandisingFlag",20000, merchandising, true));
        unlockables.Add(new Unlockable("glitterFlag",80000, glitter, true));


    }

    void ResetProgress()
    {
        for(int i = 0; i < unlockables.Count; i++)
        {
            unlockables[i].LockMe();
        }
    }
}
