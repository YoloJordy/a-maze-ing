using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeFrom : MonoBehaviour
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
        timer.Reset();
        alpha = image.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(GameManager.GM.next) || buttonPressed)
        {
            timer.start = true;
            buttonPressed = false;
        }

        if (timer.start)
        {
            Debug.Log("check");
            alpha -= (Time.deltaTime / timeToFade);
            image.color = new Color(1, 1, 1, alpha);
            done = true;
        }

        if (timer.finish && done) 
        {
            this.enabled = false;
        }

        timer.Update();
    }
}
