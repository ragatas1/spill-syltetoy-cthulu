using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC1Script : MonoBehaviour
{
    public bool harItem;
    public GameObject interaction;
    public GameObject dialog;
    public GameObject text;
    public GameObject son;
    bool snakke;
    bool interact;
    public float dialogLengde;
    [HideInInspector] public GameObject logikk;
    [HideInInspector] public LogikkScript logikkScript;
    [HideInInspector] public GameObject spiller;
    [HideInInspector] public Movement spillerScript;
    // Start is called before the first frame update
    void Start()
    {
        logikk = GameObject.FindGameObjectWithTag("Logikk");
        logikkScript = logikk.GetComponent<LogikkScript>();
        spiller = GameObject.FindGameObjectWithTag("spiller");
        spillerScript = spiller.GetComponent<Movement>();
        text.SetActive(false);
        dialog.SetActive(false);
        harItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (harItem)
        {
            son.SetActive(true);
        }
        else
        {
            son.SetActive(false);
        }
        text.SetActive(snakke);
        if(snakke) 
        {
            if (Input.GetButton("Interact"))
            {
                harItem = true;
                logikkScript.harItem1 = false;
                logikkScript.hjerteCounter = logikkScript.hjerteCounter + 1;
                snakke = false;
            }
        }
        if (interact)
        {
            if (Input.GetButtonDown("Interact"))
            {
                StartCoroutine(dialogen());
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (logikkScript.harItem1 == true)
        {
            snakke = true;
            interact = false;
        }
        else if (logikkScript.item1PlukketOpp)
        {
            snakke = false;           
        }
        else
        {
            interaction.SetActive(true);
            interact = true;
            snakke = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interaction.SetActive(false);
        snakke = false;
        interact = false;
    }
    IEnumerator dialogen()
    {
        spillerScript.moving = false;
        interaction.SetActive(false);
        dialog.SetActive(true);
        yield return new WaitForSeconds(dialogLengde);
        spillerScript.moving = true;
        dialog.SetActive(false);
        interact = false;
    }
}
