using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimationScript : MonoBehaviour {

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
    public void OnButtonClicked()
    {
        animator.SetTrigger("Clicked");
    }
}
