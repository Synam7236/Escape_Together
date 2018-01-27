using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkText_ : MonoBehaviour {

    public GameObject Text_;

    void Start()
    {
        StartCoroutine(BlinkOn());
    }

    IEnumerator BlinkOn()
    {
        yield return new WaitForSeconds(0.45f);

        StartCoroutine(BlinkOff());

        Text_.SetActive(true);
    }

    IEnumerator BlinkOff()
    {
        yield return new WaitForSeconds(0.45f);

        StartCoroutine(BlinkOn());

        Text_.SetActive(false);
    }

}
