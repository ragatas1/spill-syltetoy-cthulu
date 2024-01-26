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
    public Rigidbody2D rb;
    [HideInInspector] public int itemCount;
    public bool harItem1;
    // Start is called before the first frame update
    void Start()
    {
        harItem1 = false;
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
        rb.velocity = movement*speed;
        if (itemCount ==1)
        {
            harItem1 = true;
        }
    }
}
