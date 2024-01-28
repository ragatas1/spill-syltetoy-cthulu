using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float horizontal;
    float vertical;
    Vector2 movement;
    public float speed;
    public float runMultiplier;
    public bool freeMove;
    public Rigidbody2D rb;
    public Animator counter;
    public Animator animator;
    [HideInInspector] public GameObject logikk;
    [HideInInspector] public LogikkScript logikkScript;
    [HideInInspector] public bool moving;
    // Start is called before the first frame update
    void Start()
    {
        logikk = GameObject.FindGameObjectWithTag("Logikk");
        logikkScript = logikk.GetComponent<LogikkScript>();
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
    }
    void move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (freeMove)
        {
            movement.x = horizontal;
            movement.y = vertical;
        }
        else
        {
            if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
            {
                movement.x = horizontal;
                movement.y = 0;
            }
            else if (Mathf.Abs(horizontal) < Mathf.Abs(vertical))
            {
                movement.x = 0;
                movement.y = vertical;
            }
        }

        if (movement.magnitude > 0)
        {
            if (Input.GetButton("Run"))
            {
                rb.velocity = movement.normalized * speed * runMultiplier;
            }
            else
            {
                rb.velocity = movement.normalized * speed;
            }

            if (movement.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                animator.SetInteger("MoveDirection", 3);
            }
            else if (movement.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                animator.SetInteger("MoveDirection", 3);
            }
            else if (movement.y > 0)
            {
                animator.SetInteger("MoveDirection", 2);
            }
            else if (movement.y < 0)
            {
                animator.SetInteger("MoveDirection", 1);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            animator.SetInteger("MoveDirection", 0);
        }
    }
}
