using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("num_enigme", 0);
        PlayerPrefs.SetInt("karma", 70);
        PlayerPrefs.SetInt("nbreInsultes", 0);
        PlayerPrefs.SetInt("Suite", 1);
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("GameScene");
        }
	}
}
