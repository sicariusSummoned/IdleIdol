using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	public GameObject mainMenu;
	public GameObject credits;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void ClickCreds()
	{
		credits.SetActive(true);
		mainMenu.SetActive(false);
	}
	public void back()
	{
		mainMenu.SetActive(true);
		credits.SetActive(false);
	}

	public void Play(){

        if (PlayerPrefs.GetInt("isGirl", -1) == -1)
        {
            SceneManager.LoadScene("CharacterSelect");
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
	}

    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

}
