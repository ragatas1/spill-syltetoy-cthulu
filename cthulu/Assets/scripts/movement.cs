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
    Animator animator;
    public Animator counter;
    [HideInInspector] public GameObject logikk;
    [HideInInspector] public LogikkScript logikkScript;
    [HideInInspector] public bool moving;
    // Start is called before the first frame update
    void Start()
    {
        logikk = GameObject.FindGameObjectWithTag("Logikk");
        logikkScript = logikk.GetComponent<LogikkScript>();
        animator = GetComponent<Animator>();
        transform.position = logikkScript.spillerPosisjon;
        moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        counter.SetInteger("HjerteCounter", logikkScript.hjerteCounter);
        if (moving)
        {
            move();
        }
        logikkScript.spillerPosisjon = transform.position;
    }
    void move()
    {
        rb.velocity = movement * speed;
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
        if (x > y)
        {
            animator.SetInteger("MoveDirection", 3);
            if (horizontal < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else if (x < y)
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
        else if (x == 0 && y == 0)
        {
            animator.SetInteger("MoveDirection", 0);
        }
    }
}
