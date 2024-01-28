using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPC5Script : MonoBehaviour
{
    public GameObject portrait;
    public Animator portraitA;
    public GameObject interaction;
    public GameObject dialog;
    public Dialogue dialogScript;
    public GameObject winDialog;
    public Dialogue winDialogScript;
    public GameObject death;
    public Dialogue deathD;
    public GameObject tower;
    public Dialogue towerD;
    public GameObject devil;
    public Dialogue devilD;
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
        if (logikkScript.tarotDialog)
        {
            if (logikkScript.hvilkenTarrot == 1) { StartCoroutine(Death()); }
            if (logikkScript.hvilkenTarrot == 2) { StartCoroutine(Tower()); }
            if (logikkScript.hvilkenTarrot == 3) { StartCoroutine(Devil()); }
        }
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
        if (logikkScript.harItem5 == true)
        {
            snakke = true;
            interact = false;
            text.SetActive(true);
        }
        else if (logikkScript.item5PlukketOpp)
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
        logikkScript.harItem5 = false;
        logikkScript.hjerteCounter = logikkScript.hjerteCounter + 1;
        snakke = false;
        portrait.SetActive(false);
        logikkScript.fornoyd5 = true;
        SceneManager.LoadScene("tarot");
    }
    IEnumerator Death()
    {
        interact = false;
        deathD.ferdig = false;
        deathD.index = 0;
        spillerScript.moving = false;
        interaction.SetActive(false);
        death.SetActive(true);
        portrait.SetActive(true);
        deathD.NextLine();
        yield return new WaitUntil(() => deathD.ferdig == true);
        spillerScript.moving = true;
        death.SetActive(false);
        interact = false;
        portrait.SetActive(false);
    }
    IEnumerator Tower()
    {
        interact = false;
        towerD.ferdig = false;
        towerD.index = 0;
        spillerScript.moving = false;
        interaction.SetActive(false);
        tower.SetActive(true);
        portrait.SetActive(true);
        towerD.NextLine();
        yield return new WaitUntil(() => towerD.ferdig == true);
        spillerScript.moving = true;
        tower.SetActive(false);
        interact = false;
        portrait.SetActive(false);
    }
    IEnumerator Devil()
    {
        interact = false;
        devilD.ferdig = false;
        devilD.index = 0;
        spillerScript.moving = false;
        interaction.SetActive(false);
        devil.SetActive(true);
        portrait.SetActive(true);
        devilD.NextLine();
        yield return new WaitUntil(() => devilD.ferdig == true);
        spillerScript.moving = true;
        devil.SetActive(false);
        interact = false;
        portrait.SetActive(false);
    }

    void endreAnsikt()
    {
        if (dialogScript.index == 1) { portraitA.SetInteger("hvilketAnsikt", 40); }
        if (dialogScript.index == 2) { portraitA.SetInteger("hvilketAnsikt", 1); }
        if (dialogScript.index == 3) { portraitA.SetInteger("hvilketAnsikt", 40); }
        if (dialogScript.index == 4) { portraitA.SetInteger("hvilketAnsikt", 0); }
        if (dialogScript.index == 5) { portraitA.SetInteger("hvilketAnsikt", 40); }
        if (dialogScript.index == 6) { portraitA.SetInteger("hvilketAnsikt", 0); }
        if (dialogScript.index == 7) { portraitA.SetInteger("hvilketAnsikt", 41); }
        if (dialogScript.index == 8) { portraitA.SetInteger("hvilketAnsikt", 40); }
        if (dialogScript.index == 9) { portraitA.SetInteger("hvilketAnsikt", 40); }

        if (winDialogScript.index == 1) { portraitA.SetInteger("hvilketAnsikt", 41); }
        if (winDialogScript.index == 2) { portraitA.SetInteger("hvilketAnsikt", 40); }
        if (winDialogScript.index == 3) { portraitA.SetInteger("hvilketAnsikt", 0); }
        if (winDialogScript.index == 4) { portraitA.SetInteger("hvilketAnsikt", 40); }
        if (winDialogScript.index == 5) { portraitA.SetInteger("hvilketAnsikt", 3); }
        if (winDialogScript.index == 6) { portraitA.SetInteger("hvilketAnsikt", 41); }

        if (deathD.index == 1) { portraitA.SetInteger("hvilketAnsikt", 0); }
        if (deathD.index == 2) { portraitA.SetInteger("hvilketAnsikt", 40); }
        if (deathD.index == 3) { portraitA.SetInteger("hvilketAnsikt", 0); }
        if (deathD.index == 4) { portraitA.SetInteger("hvilketAnsikt", 41); }

        if (towerD.index == 1) { portraitA.SetInteger("hvilketAnsikt", 40); }
        if (towerD.index == 2) { portraitA.SetInteger("hvilketAnsikt", 40); }
        if (towerD.index == 2) { portraitA.SetInteger("hvilketAnsikt", 41); }

        if (devilD.index == 1) { portraitA.SetInteger("hvilketAnsikt", 40); }
        if (devilD.index == 1) { portraitA.SetInteger("hvilketAnsikt", 41); }
        if (devilD.index == 1) { portraitA.SetInteger("hvilketAnsikt", 40); }



    }
}
