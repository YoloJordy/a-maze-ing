using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    AudioSource audio;
    public AudioClip menu, level;
    private AudioClip current;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        audio = GetComponent<AudioSource>();
        current = audio.clip;
    }

    // Update is called once per frame
    void Update()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Opening":
                if (current == level)
                {
                    current = menu;
                    audio.clip = current;
                    audio.Play();
                }
                break;
            case "MenuMain":
                if (current == level)
                {
                    current = menu;
                    audio.clip = current;
                    audio.Play();
                }
                break;
            case "Scores":
                if (current == level)
                {
                    current = menu;
                    audio.clip = current;
                    audio.Play();
                }
                break;
            case "LevelSelector":
                if (current == level)
                {
                    current = menu;
                    audio.clip = current;
                    audio.Play();
                }
                break;
            case "End":
                if (current == level)
                {
                    current = menu;
                    audio.clip = current;
                    audio.Play();
                }
                break;
            case "Level 1":
                if (current == menu)
                {
                    current = level;
                    audio.clip = current;
                    audio.Play();
                }
                break;
            case "Level 2":
                if (current == menu)
                {
                    current = level;
                    audio.clip = current;
                    audio.Play();
                }
                break;
            case "Level 3":
                if (current == menu)
                {
                    current = level;
                    audio.clip = current;
                    audio.Play();
                }
                break;
            case "Tutorial":
                if (current == menu)
                {
                    current = level;
                    audio.clip = current;
                    audio.Play();
                }
                break;
        }
    }
}
