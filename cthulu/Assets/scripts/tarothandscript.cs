using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tarothandscript : MonoBehaviour
{
    float horizontal;
    int hvilketValg;
    public int hvorMangeValg;
    public Vector3 hvor;
    public float y;
    public float z;
    public float hvorEr1;
    public float hvorEr2;
    public float hvorEr3;
    public float tid;
    float timer;
    bool tattKort;
    
    // Start is called before the first frame update
    void Start()
    {
        hvor = new Vector3 (hvorEr2, y, z);
        hvilketValg = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            tattKort = true;
        }
        if(tattKort)
        {
            hvor.y = hvor.y + 5 *Time.deltaTime;
        }
        transform.position = hvor;
        horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal != 0)
        {
            timer = timer +1*Time.deltaTime;
        }
        else
        {
            timer = tid;
        }
        if (horizontal > 0 && timer> tid)
        {
            hvilketValg = hvilketValg + 1;
            timer = 0;
        }
        else if (horizontal < 0 && timer > tid)
        {
            hvilketValg = hvilketValg - 1;
            timer = 0;
        }
        if (hvilketValg <= 0)
        {
            hvilketValg = hvorMangeValg;
        }
        else if (hvilketValg > hvorMangeValg)
        {
            hvilketValg = 1;
        }
        if (hvilketValg == 1) { hvor.x = hvorEr1;}
        else if (hvilketValg == 2) { hvor.x = hvorEr2;}
        else if (hvilketValg == 3) { hvor.x = hvorEr3;}
    }
}
