using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickUpgrade : UpgradeScript {

    //uses base logic and then tells game manager to update the click score.
    public override void OnBuy()
    {
        base.OnBuy();

        GameManager.clickFlag = true;
    }
}
