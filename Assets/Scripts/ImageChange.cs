using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour {

	public Image changeImage;//the image that will be change to the idol
	// Use this for initialization
	public Sprite girlD;//girl idol default
	public Sprite boyD;//boy diol default
	void Start () {
		if (PlayerPrefs.GetInt ("isGirl") == 1) {
			changeImage.sprite = girlD;
		} else if (PlayerPrefs.GetInt ("isGirl") == 0) {//default also will show a boy
			changeImage.sprite = boyD;
		}
	

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
