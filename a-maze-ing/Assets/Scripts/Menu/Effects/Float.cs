using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    private float sinX;
    [SerializeField] private float SinXIncrement;
    [SerializeField] private float Amplitude;

    private Vector2 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        sinX += SinXIncrement * Time.deltaTime;
        var sinMovement = Mathf.Sin(sinX) * Amplitude;

        transform.position = new Vector2(transform.position.x, startPosition.y + sinMovement);
    }
}
