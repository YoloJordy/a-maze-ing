using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Teleporter : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] string nextScene;
    public GameObject screenFader;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player") 
        {
            SendSaveData();
            FaderOn();
            Invoke("loadNextScene", time);
        }
    }

    void SendSaveData()
    {
        float time = Time.timeSinceLevelLoad;

        //gets what level is currently loaded
        string sceneName = SceneManager.GetActiveScene().name;
        char[] level = new char[1];
        sceneName.CopyTo(sceneName.Length - 1, level, 0, 1);
        if (char.IsNumber(level[0]))
        {
            //makes char into int
            int levelNumber = int.Parse(level[0].ToString());
        
            //sends data to file
            SaveFileHandler.SaveTimeData(levelNumber, time);
        }
    }

    void loadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    void FaderOn()
    {
        screenFader.SetActive(true);
        GetComponent<FadeTo>().enabled = true;
        GetComponent<FadeTo>().buttonPressed = true;
    }
}
