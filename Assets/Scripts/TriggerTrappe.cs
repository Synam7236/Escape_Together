using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrappe : MonoBehaviour {
    public GameObject Trappe;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && PlayerPrefs.GetInt("num_enigme") == 6)
        {
            rb = Trappe.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            Debug.Log("ALLO");
        }
    }
}
