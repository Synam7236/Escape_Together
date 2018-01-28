using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirerObj : MonoBehaviour {

	public GameObject LeText;
	private GameObject GoName;

	/*var tiroir:GameObject;
	var posDebut : Vector3;

	function Awake(){
		posDebut = tiroir.transform.position;
	}
	function FixedUpdate() {
		if(Input.GetKeyDown(KeyCode.E)) {
			tiroir.transform.Translate(1,1,1);
		}
		if(Input.GetKeyDown(KeyCode.F)) {
			tiroir.transform.position = posDebut  
		}
	}*/

	void Start () {
	}




	// Update is called once per frame
	void Update () {

		/*if(Input.GetKeyDown(KeyCode.E)){
			GoName.transform.position = new Vector3 (GoName.position.x+1, GoName.position.y+1, GoName.position.z+1);
		}*/

	}



	void OnTriggerEnter (Collider Col){
		if (Col.gameObject.tag == "tirable") {

			print ("dans le trigger");

			LeText.SetActive(true);
			GoName = Col.gameObject;

		}
	}

	void OnTriggerExit (Collider Col){
		if (Col.gameObject.tag == "tirable") {
			print ("exit le trigger");

			LeText.SetActive(false);
		}
	}
}