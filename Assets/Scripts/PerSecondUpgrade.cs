using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerSecondUpgrade : UpgradeScript {
    
    //uses base logic and then tells game manager to update the auto gen score.
    public override void OnBuy()
    {
        base.OnBuy();

        GameManager.autoGenFlag = true;
    }
}
