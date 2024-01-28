using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daddyFixScript : MonoBehaviour
{
    public GameObject daddy;
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
        if (logikkScript.father) 
        {
            daddy.SetActive(true);
        }
    }
}
