using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFlickering : MonoBehaviour
{
    public Image image;
    [SerializeField] float timeVisible, timeStayingVisible, timeInvisible;
    private Timer toInvisibleTimer, toVisibleTimer, visibleTimer;
    private bool onceVisible, onceStayingVisible, onceInvisible;
    private float alpha;

    // Start is called before the first frame update
    void Start()
    {
        alpha = image.color.a;

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

        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
        toInvisibleTimer.Update();
        toVisibleTimer.Update();
        visibleTimer.Update();
    }
}
