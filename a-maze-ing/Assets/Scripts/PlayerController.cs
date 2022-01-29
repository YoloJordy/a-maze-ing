using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    [SerializeField] float speed = 1;
    Animator animator;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        body.velocity = new Vector2(HorizontalInput * speed, VerticalInput * speed);

        if (animator != null) animator.SetBool("IsWalking", body.velocity.sqrMagnitude != 0);
    }

    float HorizontalInput
    {
        //get { return Input.GetAxis("Horizontal"); }
        get
        {
            float x = Input.GetAxis("Horizontal");
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
            float y = Input.GetAxis("Vertical");
            if (y != 0)
                return y < 0 ? -1 : 1;
            else return 0;
        }
    }
}
