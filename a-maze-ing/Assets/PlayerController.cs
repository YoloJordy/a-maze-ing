using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    [SerializeField] float speed = 1;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //body.AddForce(new Vector2(HorizontalInput * speed, VerticalInput * speed));
        //body.velocity = 
    }

    float HorizontalInput
    {
        get { return Input.GetAxis("Horizontal"); }
    }
    float VerticalInput
    {
        get { return Input.GetAxis("Vertical"); }
    }
}
