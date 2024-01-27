using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraScript : MonoBehaviour
{
    GameObject spiller;
    Transform spillerT;
    public float upperDeadZone;
    public float lowerDeadZone;
    public float rigthDeadZone;
    public float leftDeadZone;
    Vector3 posisjon;
    // Start is called before the first frame update
    void Start()
    {
        spiller = GameObject.FindGameObjectWithTag("spiller");
        spillerT = spiller.transform;
        posisjon.z = transform.position.z;
    }


    // Update is called once per frame
    void Update()
    {
        if (spillerT.position.y<upperDeadZone && spillerT.position.y>lowerDeadZone)
        {
            posisjon.y = spillerT.position.y;
        }
        if (spillerT.position.x < rigthDeadZone && spillerT.position.x > leftDeadZone)
        {
            posisjon.x = spillerT.position.x;
        }
        transform.position = posisjon;
    }
}
