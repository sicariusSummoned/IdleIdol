using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimationScript : MonoBehaviour {

    enum IdolMood { Bored, Happy, Normal };

    Animator animator;
    private float thisTime;             //counter for time between mood changes
    private int numClicksMoodChange;    //number of times the button has been clicked since last mood change
    public int happyThreshold;          //number of clicks needed to move to happy mood
    private IdolMood currentMood;

    public Image idolImageTarget;

    public Sprite galNeutral;
    public Sprite galBored;
    public Sprite galHappy;

    public Sprite guyNeutral;
    public Sprite guyBored;
    public Sprite guyHappy;

    private Sprite idolHappy;
    private Sprite idolNeutral;
    private Sprite idolBored;

    // Use this for initialization
    void Start () {
        thisTime = 0;
        numClicksMoodChange = 0;
        currentMood = IdolMood.Normal;
        animator = GetComponent<Animator>();
        
        //Determine image set
        if (PlayerPrefs.GetInt("isGirl") == 1)
        {
            idolHappy = galHappy;
            idolBored = galBored;
            idolNeutral = galNeutral;
        }
        else
        {
            idolHappy = guyHappy;
            idolBored = guyBored;
            idolNeutral = guyNeutral;
        }
        idolImageTarget.sprite = idolNeutral;
	}

    void Update()
    {
        //increment timer
        thisTime++;

        //as long as the button has been clicked once and at least 4 seconds have passed, handle clickbased changes
        if (thisTime >= 240 && numClicksMoodChange != 0)
        {
            //check if large amounts of clicking done in the past 4 seconds
            if (numClicksMoodChange >= happyThreshold)
            {
                //change to happy mood if not already happy (nested to avoid swapping normal to happy to normal in a loop from lots of clicking
                if (currentMood != IdolMood.Happy)
                {
                    HappyIdol();
                }
            }
            else if (currentMood != IdolMood.Normal)
            {
                //change to normal mood
                NormalIdol();
            }
            //reset timer and numClicksMade
            thisTime = 0;
            numClicksMoodChange = 0;
        }
        else if (thisTime >= 240 && currentMood != IdolMood.Bored)
        {
            //if the button has never been clicked and 20 seconds passed, make the idol bored
            BoredIdol();

            //reset timer
            thisTime = 0;
        }
    }
	
    public void OnButtonClicked()
    {
        animator.SetTrigger("Clicked");
        numClicksMoodChange++;
    }

    //change the idol image ot the bored image
    private void BoredIdol()
    {
        //change mood
        currentMood = IdolMood.Bored;

        //change image
        idolImageTarget.sprite = idolBored;
        Debug.Log("I'm so bored, click a little");
    }

    //change the idol image to the normal image
    private void NormalIdol()
    {
        //change mood
        currentMood = IdolMood.Normal;

        //change image
        idolImageTarget.sprite = idolNeutral;
        Debug.Log("Oh good, you are actually playing");
    }

    //change the idol image to the happy image
    private void HappyIdol()
    {
        //change mood
        currentMood = IdolMood.Happy;

        //change image
        idolImageTarget.sprite = idolHappy;
        Debug.Log("Click me even more");
    }
}
