using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerSecondUpgrade : UpgradeScript {

	// Use this for initialization
	void Start () {
		
	}

    public override double SendValue()
    {
        return currentScoreBenefit;
    }

}
