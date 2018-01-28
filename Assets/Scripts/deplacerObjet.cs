using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deplacerObjet : MonoBehaviour {

	private bool Prend = false;
	public GameObject LeText;
	private GameObject GoName;

	public Transform EjecTransf;
	public int Force;

	// Use this for initialization
	void Start () {
		LeText.SetActive(false);
	}

	void Lance(){
		GoName.gameObject.transform.parent = null;
		GoName.gameObject.GetComponent<Rigidbody>().isKinematic = false;
		GoName.GetComponent<Rigidbody>().AddForce(transform.TransformDirection (Vector3.forward * Force));
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.E) && Prend && GoName != null){
			GoName.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			GoName.transform.position = new Vector3 (EjecTransf.position.x, EjecTransf.position.y, EjecTransf.position.z);
			GoName.gameObject.transform.parent = GameObject.Find ("Eject").transform;
		}

		if(Input.GetKeyDown("f") /* && GoName!=null*/){
			Lance ();
		}
	}



	void OnTriggerEnter (Collider Col){
		if (Col.gameObject.tag == "deplacable") {

			print ("dans le trigger");

			LeText.SetActive(true);
			GoName = Col.gameObject;
			Prend = true;


		}
	}

	void OnTriggerExit (Collider Col){
		if (Col.gameObject.tag == "deplacable") {
			print ("exit le trigger");

			LeText.SetActive(false);
			//GoName = null;
			Prend = false;
		}
	}
}
