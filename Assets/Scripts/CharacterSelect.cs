using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour {

	//determining if the boi or girl has been selected
	public static bool boySelected = false;
	public static bool girlSelected = false;
	public Button play;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!boySelected && !girlSelected) {
			play.interactable = false;
		}
		if (boySelected || girlSelected) {
			play.interactable = true;
		}
	}


	public void clickGirl(){
		boySelected = false;
		girlSelected = true;
        PlayerPrefs.SetString("character", "girl");
	}

	public void clickBoy(){
		boySelected = true;
		girlSelected = false;
        PlayerPrefs.SetString("character", "boy");
	}

	public void LoadScene(){
		SceneManager.LoadScene ("MainGame");

	}

}
