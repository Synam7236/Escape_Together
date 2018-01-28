using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public int Minutes = 0;
    public int Seconds = 0;

    private Text m_text;
    private float m_leftTime;

    private void Awake()
    {
        m_text = GetComponent<Text>();
        m_leftTime = GetInitialTime();
    }

    private void Update()
    {
        if (m_leftTime > 0f)
        {
            m_leftTime -= Time.deltaTime;
            Minutes = GetLeftMinutes();
            Seconds = GetLeftSeconds();
            
            if (m_leftTime > 0f)
            {
                m_text.text = "" + Minutes + ":" + Seconds.ToString("00");
            }
            else
            {
                m_text.text = "00:00";
            }
        }

        if (Minutes == 0f && Seconds == 0f)
        {
            Minutes = 15;

            Seconds = 00;
        }
    }

    private float GetInitialTime()
    {
        return Minutes * 60f + Seconds;
    }

    private int GetLeftMinutes()
    {
        return Mathf.FloorToInt(m_leftTime / 60f);
    }

    private int GetLeftSeconds()
    {
        return Mathf.FloorToInt(m_leftTime % 60f);
    }
}