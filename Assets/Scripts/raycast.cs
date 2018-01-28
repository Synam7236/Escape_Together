using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class raycast : MonoBehaviour {

	public GameObject LeText;
	public GameObject LeTextLancer;
	public Transform EjecTransf;
	public int Force;
	private bool pris;
	private GameObject GoName;
	private string Gtag;
	private float Gdist;

	// Use this for initialization
	void Start () {
		pris = false;
		LeText.SetActive(false);
		LeTextLancer.SetActive (false);
		
	}

    

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast (transform.position, Vector3.forward, out hit)) {
			Gtag = hit.transform.gameObject.tag;
			Gdist = hit.distance;
            GoName = hit.transform.gameObject;

            if (Input.GetKeyDown(KeyCode.E) && pris == true)
            {
                LeText.SetActive(true);
                LeTextLancer.SetActive(false);
                pris = false;
                GoName.gameObject.transform.parent = null;
                GoName.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                GoName.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward * Force));
            }

            

            else if (Gtag == "deplacable" && Gdist <= 2 && pris == false) {
				LeText.SetActive (true);



                if (Input.GetKeyDown("e") && pris == false)
                {
                    LeText.SetActive(false);
                    LeTextLancer.SetActive(true);
                    GoName.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    GoName.transform.position = new Vector3(EjecTransf.position.x, EjecTransf.position.y, EjecTransf.position.z);
                    GoName.gameObject.transform.parent = GameObject.Find("Eject").transform;
                    pris = true;
                }



            }
		}
	}
}
