using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class klasseromColider : MonoBehaviour
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
                logikkScript.spillerPosisjon = new Vector3(-0.1f + transform.localPosition.x, -3.1f, -2);
                SceneManager.LoadScene("klasserom");
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
