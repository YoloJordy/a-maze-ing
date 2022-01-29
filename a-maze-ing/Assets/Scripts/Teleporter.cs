using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    [SerializeField] string nextScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player") loadNextScene();
    }

    void loadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
