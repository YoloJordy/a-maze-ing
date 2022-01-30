using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScores : MonoBehaviour
{
    TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();

        SaveData saveData = SaveFileHandler.LoadData();

        text.text = "Level 1: " + SecToMin(saveData.bestTimeL1) + 
                    "\nLevel 2: " + SecToMin(saveData.bestTimeL2) +
                    "\nLevel 3: " + SecToMin(saveData.bestTimeL3) + 
                    "\nTotal Play Time: " + SecToMin(saveData.totalPlayTime);
    }

    string SecToMin(float time)
    {

        float minutes = (int)(time / 60f);
        float seconds = Mathf.Round(time - (minutes * 60));
        if (seconds > 59f)
        {
            return (minutes + 1).ToString("F0") + ":0";
        }
        else { return minutes.ToString("F0") + ":" + seconds.ToString("F0"); }
    }
}
