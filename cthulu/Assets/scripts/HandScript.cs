using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    bool holderGreia;
    Vector2 movement;
    float horizontal;
    float vertical;
    public Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        movement.x = horizontal;
        movement.y = vertical;
        rb.velocity = movement*speed;
        if (holderGreia == true)
        {
            if (Input.GetButton("Interact"))
            {
                Debug.Log("tok greia");
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        holderGreia = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        holderGreia = false;
    }
}
