using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] int index;
    [SerializeField] float time;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(GameManager.GM.next)) 
        {
            Loading();
            //Invoke("Loading", time);
        }
    }

    private void Loading()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        Debug.Log(SceneManager.GetActiveScene().name);
    }
}
