using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandScript : MonoBehaviour
{
    bool holderGreia;
    Vector2 movement;
    float horizontal;
    float vertical;
    public Rigidbody2D rb;
    public float speed;
    public CollisionScript c;
    [HideInInspector] public GameObject logikk;
    [HideInInspector] public LogikkScript logikkScript;
    // Start is called before the first frame update
    void Start()
    {
        logikk = GameObject.FindGameObjectWithTag("Logikk");
        logikkScript = logikk.GetComponent<LogikkScript>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        movement.x = horizontal;
        movement.y = vertical;
        rb.velocity = movement*speed;
        if (c.colided == true)
        {
            if (Input.GetButton("Interact"))
            {
                logikkScript.harItem4 = true;
                logikkScript.item4PlukketOpp = true;
                SceneManager.LoadScene("Em");
            }
        }
    }
}
