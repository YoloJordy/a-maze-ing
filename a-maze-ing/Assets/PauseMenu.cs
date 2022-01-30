using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject player, pauseMenuUI, screenFader;
    public Button firstSelected;
    [SerializeField] float time;
    private string sceneName;
    private FadeTo fadeTo;

    private void Start()
    {
        fadeTo = GetComponent<FadeTo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            switch (GameIsPaused)
            {
                case true:
                    Resume();
                    break;
                case false:
                    Pause();
                    break;
            }
        }

        if (Input.GetKeyDown(GameManager.GM.next))
        {
            var button = EventSystem.current.currentSelectedGameObject;
            button.GetComponent<Button>().onClick.Invoke();
            Time.timeScale = 1f;
        }
    }

    public void Resume() 
    {
        pauseMenuUI.SetActive(false); 
        Time.timeScale = 1f;
        GameIsPaused = false;
        player.GetComponent<PlayerController>().enabled = true;
    }

    private void Pause()
    {
        EventSystem.current.SetSelectedGameObject(firstSelected.gameObject);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        player.GetComponent<PlayerController>().enabled = false;
    }
    public void NextScene(string name)
    {
        sceneName = name;
        screenFader.SetActive(true);
        fadeTo.enabled = true;
        fadeTo.buttonPressed = true;
        Invoke("Loading", time);
    }
    private void Loading()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        screenFader.SetActive(true);
        fadeTo.enabled = true;
        fadeTo.buttonPressed = true;
        Invoke("Exiting", time);
    }

    private void Exiting()
    {
        Application.Quit();
    }
}
