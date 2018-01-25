using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomUpgradeScript : MonoBehaviour {

    //variables
    private int despawnTime;        //time until the "golden cookie" despawns. 3 to 5 seconds
    private int counter;            //counter for the despawn timer
    private int value;              //point value of the "golden cookie"

    // Use this for initialization
    void Start () {
        despawnTime = Random.Range(180, 300);
        counter = 0;
        value = Random.Range(180, 300);     //TODO find a way to pass in values for the "golden cookie" to be worth based on game length
    }
	
	// Update is called once per frame
	void Update () {
        counter++;
        if (counter >= despawnTime)
        {
            //destroy object TODO
        }
	}

    public void onClick()
    {
        //get game manager and its script
        GameObject manager = GameObject.FindGameObjectWithTag("GameManager");
        GameManagerScript script = manager.GetComponent(typeof(GameManagerScript)) as GameManagerScript;

        //add the "golden cookie"s value to the scripts player score
        script.PlayerScore += value;

        //destroy object TODO

    }
}
