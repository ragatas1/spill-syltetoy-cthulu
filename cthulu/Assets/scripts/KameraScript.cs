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
    public float startY;
    public float startX;
    public bool frittKamera = false;
    // Start is called before the first frame update
    void Start()
    {
        spiller = GameObject.FindGameObjectWithTag("spiller");
        spillerT = spiller.transform;
        posisjon.z = transform.position.z;
        posisjon.y = startY;
        posisjon.x = startX;
    }


    // Update is called once per frame
    void Update()
    {
        if (frittKamera)
        {
            if (spillerT.position.y < upperDeadZone && spillerT.position.y > lowerDeadZone)
            {
                posisjon.y = spillerT.position.y;
            }
            if (spillerT.position.x < rigthDeadZone && spillerT.position.x > leftDeadZone)
            {
                posisjon.x = spillerT.position.x;
            }
        }
        else
        {
            posisjon.x = spillerT.position.x;
            posisjon.y = spillerT.position.y;
        }
            transform.position = posisjon;
        
    
    }
}
