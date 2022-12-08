using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    // directly give your field the correct type
    public TextMeshProUGUI timeText;
    //public int secondsLeft = 1200;
    //private bool mazeEntered = false;
    //private bool gameEnded = false;

    public bool TimerOn;
    public float seconds, minutes;

    void Start()
    {
        TimerOn = false;
        timeText = GetComponent<TextMeshProUGUI>();
        timeText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (TimerOn = true)
        {
            minutes = (int)(Time.time / 60f);
            seconds = (int)(Time.time % 60f);
            timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box1"))
        {
            TimerOn = true;
        }
        else if (other.gameObject.CompareTag("Box2"))
        {
            TimerOn = false;
        }
    }
}
