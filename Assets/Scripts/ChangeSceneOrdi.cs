using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOrdi : MonoBehaviour {
    public void OnTriggerStay(Collider other)
    {
       if (Input.GetKeyDown("e"))
        {
            Debug.Log("Chargement");
            SceneManager.LoadScene("InterfaceOrdi");
            Debug.Log("Fin");
        }

    }

    // Use this for initialization
    void Start () {
        Debug.Log(PlayerPrefs.GetInt("num_enigme"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
