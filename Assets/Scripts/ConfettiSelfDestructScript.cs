﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiSelfDestructScript : MonoBehaviour {

    public float life = 5.0f;

	// Use this for initialization
	void Start () {
        Destroy(GetComponent<GameObject>(), life);
	}
	
}
