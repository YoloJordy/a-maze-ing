using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeTo : MonoBehaviour
{
    public Image image;
    [SerializeField] float timeToFade;
    [HideInInspector] public bool buttonPressed;

    private Timer timer;
    private float alpha;
    private bool done;

    // Start is called before the first frame update
    void Start()
    {
        timer = new Timer(timeToFade);
        alpha = image.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(GameManager.GM.next) || buttonPressed) && !done)
        {
            timer.start = true;
            alpha = 0f;
            buttonPressed = false;
        }

        if (timer.start)
        {
            alpha += (Time.deltaTime / timeToFade);
            image.color = new Color(1, 1, 1, alpha);
            done = true;
        }

        timer.Update();
    }
}
