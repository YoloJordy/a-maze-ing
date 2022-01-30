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
            FaderOn();
            Invoke("loadNextScene", time);
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
