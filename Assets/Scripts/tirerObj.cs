using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirerObj : MonoBehaviour {

	public GameObject LeText;
	private GameObject GoName;
	private Animator anim;
	private bool active;

	void Start () {
		active = false;
		LeText.SetActive(false);
		anim = GetComponent<Animator> ();
	}




	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.E) && active){
			anim.SetBool ("triggered", true);
		}

		if(active==false){
			anim.SetBool ("triggered", false);
		}

	}



	void OnTriggerEnter (Collider Col, Animator anima){
		if (Col.gameObject.tag == "tirable") {

			print ("dans le trigger");
			active = true;
			LeText.SetActive(true);
			GoName = Col.gameObject;
			/*anim = anima.animator;*/

		}
	}

	void OnTriggerExit (Collider Col){
		if (Col.gameObject.tag == "tirable") {
			print ("exit le trigger");
			active = false;
			LeText.SetActive(false);
		}
	}
}