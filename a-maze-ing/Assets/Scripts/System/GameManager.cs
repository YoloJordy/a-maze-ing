using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public KeyCode next { get; set; }
    public KeyCode change { get; set; }

    //make a singleton of this class
    private void Awake()
    {
        if (GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        }
        else if (GM != this)
        {
            Destroy(gameObject);
        }

        next = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("next", "F"));
        next = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("change", "Mouse0"));

    }
    //https://www.youtube.com/watch?v=iSxifRKQKAA
}
