﻿using System.Collections;
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
            quantity = 0;

            OnBuyNoDecrease();
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

        if (GameManager.PlayerScore >= currentCost && quantity < 1 && GameManager.TotalScore >= baseThreshold)
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
        if (quantity < 1)
        {
            //subtract the cost
            GameManager.DecreaseScore(currentCost);

            //increase quantity
            quantity++;

            PlayerPrefs.SetInt(name, quantity);

            currentScoreBenefit = currentValue * quantity;

            GameManager.clickPercentScoreIncrease += (currentValue/100);
        }
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
