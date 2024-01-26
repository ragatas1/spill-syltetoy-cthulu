using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float horizontal;
    float vertical;
    float x;
    float y;
    Vector2 movement;
    public float speed;
    public bool freeMove;
    public Rigidbody2D rb;
    [HideInInspector] public int itemCount;
    public bool harItem1;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        harItem1 = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (horizontal > -horizontal)
        {
            x = horizontal;
        }
        else if (horizontal < -horizontal)
        {
            x = -horizontal;
        }
        else
        {
            x = 0;
        }
        if (vertical > -vertical)
        {
            y = vertical;
        }
        else if (vertical < -vertical)
        {
            y = -vertical;
        }
        else
        {
            y = 0;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (freeMove)
        {
            movement.x = horizontal;
            movement.y = vertical;
        }
        else
        {
            if (x > y)
            {
                movement.x = horizontal;
                movement.y = 0;
            }
            if (x < y)
            {
                movement.x = 0;
                movement.y = vertical;
            }
        }
        if (x >y)
        {
            animator.SetInteger("MoveDirection", 3);
        }
        else if (x<y) 
        {
            if (vertical < 0)
            {
                animator.SetInteger("MoveDirection", 1);
            }
            else
            {
                animator.SetInteger("MoveDirection", 2);
            }
        }
        else if (x==0 && y==0)
        {
            animator.SetInteger("MoveDirection", 0);
        }
        if (horizontal<0)
        {
            transform.localScale = new Vector3(-4, 4, 4);
        }
        else
        {
            transform.localScale = new Vector3(4,4,4);
        }
        rb.velocity = movement*speed;
        if (itemCount ==1)
        {
            harItem1 = true;
        }
    }
}
