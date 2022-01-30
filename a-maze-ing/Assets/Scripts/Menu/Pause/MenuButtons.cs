using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
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

    private void Update()
    {
        switch (keyDown)
        {
            case false:
                if (button.gameObject == EventSystem.current.currentSelectedGameObject)
                {
                    CurrentlySelected(button.colors.selectedColor, false);
                }
                else
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
                Select();
                CurrentlySelected(button.colors.pressedColor, false);
            }
        }
    }

    private void CurrentlySelected(Color targetColor, bool instant)
    {
        targetGraphic.CrossFadeColor(targetColor, instant ? 0f : button.colors.fadeDuration, true, true);
    }

    private void Select()
    {
        var newColorBlock = button.colors;
        newColorBlock.disabledColor = button.colors.highlightedColor;
        button.colors = newColorBlock;

        var objects = GameObject.FindGameObjectsWithTag("Button");
        foreach (GameObject button in objects)
        {
            button.GetComponent<Button>().interactable = false;
        }
    }
}
