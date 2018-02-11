using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MultiplierResearch : UpgradeScript {
    public UpgradeScript baseUpgrade;

    // Use this for initialization
    private void Awake()
    {
        btn = button.GetComponent<Button>();
    }
    void Start()
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Let's truncate the costs before we print them
        double simpleCost = Math.Round(currentCost, 2);
        double simpleValue = Math.Round(currentValue, 2);


        costDisplay.text = "Price: " + simpleCost;
        quantityDisplay.text = "Owned: " + quantity;
        valueDisplay.text = "Multiplier: " + simpleValue;

        if (GameManager.PlayerScore >= currentCost && quantity < 1)
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

            baseUpgrade.multiplier = (int) currentValue;
        }
    }
}
