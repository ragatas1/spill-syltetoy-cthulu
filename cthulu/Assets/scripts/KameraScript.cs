using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraScript : MonoBehaviour
{
    GameObject spiller;
    Transform spillerT;
    // Start is called before the first frame update
    void Start()
    {
        spiller = GameObject.FindGameObjectWithTag("spiller");
        spillerT = spiller.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3( spillerT.position.x,spillerT.position.y,transform.position.z);
    }
}
