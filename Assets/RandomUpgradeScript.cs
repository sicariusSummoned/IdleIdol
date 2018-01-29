using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomUpgradeScript : MonoBehaviour {

    //variables
    private int spawnTime;          //time until the "golden cookie" spawns.
    private int despawnTime;        //time until the "golden cookie" despawns. 3 to 5 seconds
    private int counter;            //counter for the spawn and despawn timers
    private int value;              //point value of the "golden cookie"
    private bool visible;           //is the object visible and clickable?

    // Use this for initialization
    void Start () {
        spawnTime = Random.Range(180, 300);         //TODO change to longer amount of time
        counter = 0;
        value = Random.Range(180, 300);     //TODO find a way to pass in values for the "golden cookie" to be worth based on game length
        visible = false;
        this.gameObject.transform.position = new Vector3(5000, 5000, 0);        //set the object off screen/ make it "invisible"
    }
	
	// Update is called once per frame
	void Update () {
        //increment counter
        counter++;
        
        //if visible, see if need to despawn
        if (visible && counter >= despawnTime)
        {
            System.Console.Write("despawning");
            Despawn();
        }

        //if not visible, see if need to spawn
        if (counter >= spawnTime && !visible)
        {
            System.Console.Write("spawning");
            Spawn();
        }

    }

    //if visible, add score to the player
    public void OnClick()
    {
        if (visible)
        {
            //get game manager and its script
            GameObject manager = GameObject.FindGameObjectWithTag("GameManager");
            GameManagerScript script = manager.GetComponent(typeof(GameManagerScript)) as GameManagerScript;

            //add the "golden cookie"s value to the scripts player score
            script.PlayerScore += value;

            //destroy object
            Despawn();
        }
    }

    //make the object visible
    private void Spawn()
    {
        //make visible
        visible = true;
        this.gameObject.transform.position = new Vector3(Random.Range(-300, 300), Random.Range(-180, 180), 0);
        System.Console.Write(this.gameObject.transform.position);

        //set despawn time
        despawnTime = Random.Range(180, 300);

        //reset counter
        counter = 0;
    }

    //make the object invisible and change position
    private void Despawn()
    {
        //make invisible
        visible = false;

        //move object
        this.gameObject.transform.position = new Vector3(5000, 5000, 0);        //set the object off screen/ make it "invisible"
        System.Console.Write(this.gameObject.transform.position);

        //set spawn time
        spawnTime = Random.Range(180, 300);         //TODO change to longer amount of time

        //reset counter
        counter = 0;
    }
}
