using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC4Script : MonoBehaviour
{
    public GameObject portrait;
    public Animator portraitA;
    public GameObject interaction;
    public GameObject dialog;
    public Dialogue dialogScript;
    public GameObject winDialog;
    public Dialogue winDialogScript;
    public GameObject text;
    bool snakke;
    bool interact;
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
        portrait.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        endreAnsikt();
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
        if (logikkScript.harItem4 == true)
        {
            snakke = true;
            interact = false;
            text.SetActive(true);
        }
        else if (logikkScript.item4PlukketOpp)
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
        portrait.SetActive(true);
        dialogScript.NextLine();
        yield return new WaitUntil(() => dialogScript.ferdig == true);
        spillerScript.moving = true;
        dialog.SetActive(false);
        interact = false;
        portrait.SetActive(false);
    }
    IEnumerator winDialogen()
    {
        snakke = false;
        winDialogScript.ferdig = false;
        winDialogScript.index = 0;
        spillerScript.moving = false;
        text.SetActive(false);
        winDialog.SetActive(true);
        portrait.SetActive(true);
        winDialogScript.NextLine();
        yield return new WaitUntil(() => winDialogScript.ferdig == true);
        spillerScript.moving = true;
        winDialog.SetActive(false);
        logikkScript.harItem4 = false;
        logikkScript.hjerteCounter = logikkScript.hjerteCounter + 1;
        snakke = false;
        portrait.SetActive(false);
        logikkScript.fornoyd4 = true;
    }
    void endreAnsikt()
    {
        if (dialogScript.index == 1) { portraitA.SetInteger("hvilketAnsikt", 1); }
        if (dialogScript.index == 2) { portraitA.SetInteger("hvilketAnsikt", 31); }
        if (dialogScript.index == 3) { portraitA.SetInteger("hvilketAnsikt", 0); }
        if (dialogScript.index == 4) { portraitA.SetInteger("hvilketAnsikt", 30); }
        if (dialogScript.index == 5) { portraitA.SetInteger("hvilketAnsikt", 31); }
        if (dialogScript.index == 6) { portraitA.SetInteger("hvilketAnsikt", 30); }
        if (winDialogScript.index == 1) { portraitA.SetInteger("hvilketAnsikt", 1); }
        if (winDialogScript.index == 2) { portraitA.SetInteger("hvilketAnsikt", 30); }
        if (winDialogScript.index == 3) { portraitA.SetInteger("hvilketAnsikt", 31); }
        if (winDialogScript.index == 4) { portraitA.SetInteger("hvilketAnsikt", 1); }

    }
}
