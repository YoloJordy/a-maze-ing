using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void Exit(float time)
    {
        Invoke("Exiting", time);
    }

    public void NextScene(float time)
    {
        Invoke("Loading", time);
    }

    private void Loading()
    {
        SceneManager.LoadScene(sceneName);
    }

    private void Exiting()
    {
        Application.Quit();
    }
}
