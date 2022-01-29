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
        //move player
        body.velocity = new Vector2(HorizontalInput * speed, VerticalInput * speed);
        //set rotation
        transform.eulerAngles = new Vector3(0, 0, Vector2.SignedAngle(Vector2.right, body.velocity));
        //activates animation
        if (animator != null) animator.SetBool("IsWalking", body.velocity.sqrMagnitude != 0);
    }

    float HorizontalInput
    { 
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
        get
        {
            float y = Input.GetAxisRaw("Vertical");
            if (y != 0)
                return y < 0 ? -1 : 1;
            else return 0;
        }
    }
}
