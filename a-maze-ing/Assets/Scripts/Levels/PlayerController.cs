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
        body.velocity = new Vector2(HorizontalInput * speed, VerticalInput * speed);
    }

    float HorizontalInput
    {
        //get { return Input.GetAxis("Horizontal"); }
        get
        {
            float x = Input.GetAxisRaw("Horizontal");
            if (x != 0) 
                return x < 0 ? -1 : 1;
            else return 0;
        }
    }

    float VerticalInput
    {
        //get { return Input.GetAxis("Vertical"); }
        get
        {
            float y = Input.GetAxisRaw("Vertical");
            if (y != 0)
                return y < 0 ? -1 : 1;
            else return 0;
        }
    }
}
