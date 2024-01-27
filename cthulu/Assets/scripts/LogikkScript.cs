using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogikkScript : MonoBehaviour
{
    public int hjerteCounter;
    public bool item1PlukketOpp;
    public bool harItem1;
    public bool harSnakketMed1;
    public Vector3 spillerPosisjon;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        spillerPosisjon.z = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
