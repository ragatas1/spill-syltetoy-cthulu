using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public Dialogue script;
    [HideInInspector] public GameObject logikk;
    [HideInInspector] public LogikkScript logikkScript;
    // Update is called once per frame
    private void Start()
    {
        logikk = GameObject.FindGameObjectWithTag("Logikk");
        logikkScript = logikk.GetComponent<LogikkScript>();
    }
    void Update()
    {
        if (script.index == script.lines.Length-1)
        {
            logikkScript.spillerPosisjon = new Vector3(0,-4,-2);
            SceneManager.LoadScene("Em");
        }
    }
}
