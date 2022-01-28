using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{    
    public GameObject screenFader;
    Button button;
    bool keyDown;
    Graphic targetGraphic;

    private void Awake()
    {
        button = GetComponent<Button>();
        targetGraphic = GetComponent<Graphic>();

        if (button.gameObject == EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject) 
        {
            CurrentlySelected(button.colors.selectedColor, false);
        }
        else
        {
            CurrentlySelected(button.colors.normalColor, false);
        }

    }

    private void LateUpdate()
    {
        switch (keyDown)
        {
            case false:
                if (button.gameObject == EventSystem.current.currentSelectedGameObject)
                {
                    CurrentlySelected(button.colors.selectedColor, false);
                } else
                {
                    CurrentlySelected(button.colors.normalColor, false);
                }
                break;
            default:
                break;
        }

        if (Input.GetKeyDown(GameManager.GM.next))
        {
            keyDown = true;

            if (button.gameObject == EventSystem.current.currentSelectedGameObject)
            {
                button.onClick.Invoke();
                Invoke("FaderOn", 0f);
                CurrentlySelected(button.colors.pressedColor, false);
            }
        }
    }

    private void CurrentlySelected(Color targetColor, bool instant)
    {
        targetGraphic.CrossFadeColor(targetColor, instant ? 0f : button.colors.fadeDuration, true, true);
    }

    private void FaderOn()
    {
        var newColorBlock = button.colors;
        newColorBlock.disabledColor = button.colors.highlightedColor;
        button.colors = newColorBlock;

        screenFader.SetActive(true);
        GetComponent<FadeTo>().enabled = true;
        GetComponent<FadeTo>().buttonPressed = true;

        var objects = GameObject.FindGameObjectsWithTag("Button");
        foreach (GameObject button in objects)
        {
            button.GetComponent<Button>().interactable = false;
        }
    }
}