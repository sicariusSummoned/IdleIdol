using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiManager : MonoBehaviour {

    public ParticleSystem[] particles;
    public Transform confettiOrigin;
    Transform ourPosition;
    

	// Use this for initialization
	void Start () {
        ourPosition = GetComponent<Transform>();
    }
	
	
    public void OnActivate()
    {
        //On click give us back a random index for the confetti to be sent out.
        int index = Random.Range(0, 9);

        //Move us to mouse position
        ourPosition.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0);

        //Make it wherever origin says to.
        Instantiate<ParticleSystem>(particles[index], confettiOrigin);
    }


}
