using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(GameManager.GM.next)) 
        {
            Invoke("Loading", time);
        }
    }

    private void Loading()
    {
        SceneManager.LoadScene(sceneName);
    }
}
