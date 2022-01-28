using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Flickering : MonoBehaviour
{
    public TMP_Text text;
    [SerializeField] float timeVisible, timeStayingVisible, timeInvisible;
    private Timer toInvisibleTimer, toVisibleTimer, visibleTimer;
    private bool onceVisible, onceStayingVisible, onceInvisible;
    private float alpha;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Press " + GameManager.GM.next.ToString();
        alpha = text.color.a;

        visibleTimer = new Timer(timeStayingVisible);
        toInvisibleTimer = new Timer(timeVisible);
        toVisibleTimer = new Timer(timeInvisible);
        toInvisibleTimer.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (toInvisibleTimer.start) 
        {
            alpha -= Time.deltaTime;
            //text.gameObject.SetActive(true);
        }

        if (toInvisibleTimer.finish && !onceVisible)
        {
            toVisibleTimer.Reset();
            onceVisible = true;
            onceInvisible = false;
        }

        if (toVisibleTimer.start)
        {
            alpha += Time.deltaTime;
            //text.gameObject.SetActive(false);
        }

        if (toVisibleTimer.finish && !onceInvisible)
        {
            visibleTimer.Reset();
            onceStayingVisible = false;
            onceInvisible = true;
        }

        if (visibleTimer.finish && !onceStayingVisible)
        {
            toInvisibleTimer.Reset();
            onceVisible = false;
            onceStayingVisible = true;
        }

        text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
        //Debug.Log(text.gameObject.active.ToString());
        toInvisibleTimer.Update();
        toVisibleTimer.Update();
        visibleTimer.Update();
    }
}
