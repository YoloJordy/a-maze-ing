using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeText : MonoBehaviour
{
    public TMP_Text text;
    private float minutes, seconds;

    // Update is called once per frame
    void Update()
    {
        minutes = (int)(Time.timeSinceLevelLoad / 60f);
        seconds = Mathf.Round(Time.timeSinceLevelLoad - (minutes * 60));
        text.text = "Time: " + minutes.ToString("F0") + ":" + seconds.ToString("F0");
    }
}
