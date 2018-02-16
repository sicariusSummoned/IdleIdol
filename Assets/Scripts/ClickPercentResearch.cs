using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ClickPercentResearch : UpgradeScript
{

    // Use this for initialization
    protected virtual void Awake()
    {
        btn = button.GetComponent<Button>();
    }
    protected virtual void Start()
    {
        //initialize the private values
        quantity = 0;
        nextThreshold = baseThreshold;
        currentCost = baseCost;
        currentValue = baseValue;
        currentScoreBenefit = 0;
        GameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        if (PlayerPrefs.GetInt(name) != 0)
        {
            quantity = PlayerPrefs.GetInt(name);

            currentCost *= Math.Pow(deltaCost, quantity);

            base.Threshold();

            GameManager.clickPercentScoreIncrease += (currentValue / 100);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Let's truncate the costs before we print them
        double simpleCost = Math.Round(currentCost, 2);
        double simpleValue = Math.Round(currentValue, 2);


        costDisplay.text = "" + simpleCost;
        quantityDisplay.text = "" + quantity;
        valueDisplay.text = "" + simpleValue;

        if (GameManager.PlayerScore >= currentCost)
        {
            btn.interactable = true;
        }
        else
        {
            btn.interactable = false;
        }
    }

    public override void OnBuy()
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
            base.Threshold();
        }

        GameManager.clickPercentScoreIncrease += (currentValue/100);
    }

    private void OnBuyNoDecrease()
    {
        //increase quantity
        quantity = 1;

        PlayerPrefs.SetInt(name, quantity);

        currentScoreBenefit = currentValue * quantity;

        GameManager.clickPercentScoreIncrease += (currentValue / 100);
    }
}
