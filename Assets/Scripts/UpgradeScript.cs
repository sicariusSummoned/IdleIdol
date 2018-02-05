using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour {

    //global variables
    public double baseCost;                    //base cost to buy this upgrade
    public double deltaCost;                   //how much the cost increases with each purchase
    public double currentCost;                //the current cost to buy the upgrade
    public double baseValue;                //the base value the upgrade increases score gaining methods by
    public double deltaValue;               //the amount value is increased by when threshold is reached
    protected double currentValue;            //the current value this upgrade increases score generators by
    public int baseThreshold;               //the base quantity needed to be purchased to increase currentValue
    public int deltaThreshold;              //how much to add to nextThreshold after a threshold is reached
    protected int nextThreshold;              //the amount of quantity needed to increase the power of future purchases of this upgrade
    protected int quantity;                   //how many times this upgrade has been purchased
    protected double currentScoreBenefit;     //the current benefit this upgrade is giving to score production
    protected GameManagerScript GameManager;  //access to the game manager for interfacing purposes
    protected string name;                      //name of the upgrade, used in playerPrefs
    public Text costDisplay;
    public Text valueDisplay;
    public Text quantityDisplay;
    public Button btn;                      //the buttoncomponent for the upgrade
    public GameObject button;               //the gameobject of the button for the upgrade

    // Use this for initialization
    private void Awake()
    {
        //btn = button.GetComponent<Button>();
    }
    void Start () {
        //initialize the private values
        quantity = 0;
        nextThreshold = baseThreshold;
        currentCost = baseCost;
        currentValue = baseValue;
        currentScoreBenefit = 0;
        GameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

    }
	
	// Update is called once per frame
	void Update () {
        //place on the screen the current cost, current value, and current score benefit
        //TODO overload in the children classes to say per click or per second after the current score benefit


        //Let's truncate the costs before we print them
        double simpleCost = Math.Round(currentCost, 2);
        double simpleValue = Math.Round(currentValue, 2);


        costDisplay.text = "Price: " + simpleCost;
        quantityDisplay.text = "Owned: " + quantity;
        valueDisplay.text = "Value: " + simpleValue;

        /*
        if (GameManager.PlayerScore >= currentCost)
        {
            btn.interactable = true;
        }
        else
        {
            btn.interactable = false;
        }
        */
	}

    //handle effects of purchasing the upgrade
    //TODO probably check if the user has enough $/Fans/Value/etc in here and perform purchased actions if they do have enough, else display a message saying they dont have enough
    public virtual void OnBuy()
    {
        if (currentCost <= GameManager.PlayerScore)
        {
            //subtract the cost
            GameManager.DecreaseScore(currentCost);

            //increase cost and quantity
            currentCost *= deltaCost;
            quantity++;

            PlayerPrefs.SetInt(name, quantity);

            currentScoreBenefit = currentValue * quantity;

            //check if threshold was reached
            if (quantity >= nextThreshold)
            {
                Threshold();
            }
        }
    }

    //send the value of the upgrade to the gamemanager
    public double GetValue()
    {
        return currentScoreBenefit;
    }

    //handle effects of reaching nextThreshold
    private void Threshold()
    {
        //increase value
        currentValue += deltaValue;

        //increase nextThreshold
        nextThreshold += deltaThreshold;

        currentScoreBenefit = currentValue * quantity;
    }
}
