using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC1Script : MonoBehaviour
{
    public bool harItem;
    public GameObject interaction;
    public GameObject dialog;
    public Dialogue dialogScript;
    public GameObject winDialog;
    public Dialogue winDialogScript;
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
        winDialog.SetActive(false);
        harItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(snakke) 
        {
            if (Input.GetButton("Interact"))
            {
                StartCoroutine(winDialogen());

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
            text.SetActive(true);
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
        text.SetActive(false);
        snakke = false;
        interact = false;
    }
    IEnumerator dialogen()
    {
        interact = false;
        dialogScript.ferdig = false;
        dialogScript.index = 0;
        spillerScript.moving = false;
        interaction.SetActive(false);
        dialog.SetActive(true);
        dialogScript.NextLine();
        yield return new WaitUntil(() => dialogScript.ferdig == true);
        spillerScript.moving = true;
        dialog.SetActive(false);
        interact = false;
    }
    IEnumerator winDialogen()
    {
        snakke = false;
        winDialogScript.ferdig = false;
        winDialogScript.index = 0;
        spillerScript.moving = false;
        text.SetActive(false);
        winDialog.SetActive(true);
        winDialogScript.NextLine();
        yield return new WaitUntil(() => winDialogScript.ferdig == true);
        spillerScript.moving = true;
        winDialog.SetActive(false);
        harItem = true;
        logikkScript.harItem1 = false;
        logikkScript.hjerteCounter = logikkScript.hjerteCounter + 1;
        snakke = false;
    }
}
