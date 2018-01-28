using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

    public float degreesPerSecond;
    public bool doorOpen = false;
    public bool DoorIsMoving = true;
    public bool startCouroutine = false;
    	
	// Update is called once per frame
	void Update () {

        if(doorOpen == true)
        {
            if (DoorIsMoving == true)
            {
                startCouroutine = true;

                StartCoroutine(CountDown());

                transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);
            }
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(2);

        DoorIsMoving = false;
    }
}
