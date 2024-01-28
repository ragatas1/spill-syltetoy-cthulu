using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class utAvHippieColidor : MonoBehaviour
{
    [HideInInspector] public GameObject logikk;
    [HideInInspector] public LogikkScript logikkScript;
    bool touching;
    public GameObject interaction;
    // Start is called before the first frame update
    void Start()
    {
        logikk = GameObject.FindGameObjectWithTag("Logikk");
        logikkScript = logikk.GetComponent<LogikkScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (touching)
        {
            interaction.SetActive(true);
            if (Input.GetButtonDown("Interact"))
            {
                SceneManager.LoadScene("Em");
                logikkScript.spillerPosisjon = new Vector3(4.5f+transform.localPosition.x, 3.6f, -2);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        touching = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        touching = false;
        if (interaction != null)
        {
            interaction.SetActive(false);
        }
    }
}
