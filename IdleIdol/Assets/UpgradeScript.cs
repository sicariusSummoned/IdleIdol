using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScript : MonoBehaviour {

    //global variables
    public int baseCost;                    //base cost to buy this upgrade
    public int deltaCost;                   //how much the cost increases with each purchase
    private int currentCost;                //the current cost to buy the upgrade
    public double baseValue;                //the base value the upgrade increases score gaining methods by
    public double deltaValue;               //the amount value is increased by when threshold is reached
    private double currentValue;            //the current value this upgrade increases score generators by
    public int baseThreshold;               //the base quantity needed to be purchased to increase currentValue
    public int deltaThreshold;              //how much to add to nextThreshold after a threshold is reached
    private int nextThreshold;              //the amount of quantity needed to increase the power of future purchases of this upgrade
    private int quantity;                   //how many times this upgrade has been purchased
    private double currentScoreBenefit;     //the current benefit this upgrade is giving to score production

	// Use this for initialization
	void Start () {
        //initialize the private values
        quantity = 0;
        nextThreshold = baseThreshold;
        currentCost = baseCost;
        currentValue = baseValue;
        currentScoreBenefit = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//place on the screen the current cost, current value, and current score benefit
        //TODO overload in the children classes to say per click or per second after the current score benefit
	}

    //handle effects of purchasing the upgrade
    //TODO probably check if the user has enough $/Fans/Value/etc in here and perform purchased actions if they do have enough, else display a message saying they dont have enough
    private void OnBuy()
    {
        //increase cost and quantity
        currentCost += deltaCost;
        quantity++;

        //increase score values stored in gamemanager
        SendValue();

        //check if threshold was reached
        if (quantity >= nextThreshold)
        {
            Threshold();
        }
    }

    //send the value of the upgrade to the gamemanager
    private void SendValue()
    {
        //TODO overload in the children classes to send the value to either autogen or click scoreIncrease
        currentScoreBenefit += currentValue;
    }

    //handle effects of reaching nextThreshold
    private void Threshold()
    {
        //increase value
        currentValue += deltaValue;

        //increase nextThreshold
        nextThreshold += deltaThreshold;
    }
}
