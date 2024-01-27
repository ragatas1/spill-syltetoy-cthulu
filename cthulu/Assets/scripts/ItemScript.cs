using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemScript : MonoBehaviour
{
    GameObject spiller;
    Movement spillerScript;
    public int itemNummer;
    [HideInInspector] public GameObject logikk;
    [HideInInspector] public LogikkScript logikkScript;
    public GameObject portrett;
    [HideInInspector] public Animator porAni;
    bool iNoe;
    public GameObject interactionText;
    [HideInInspector] public GameObject dialog;
    [HideInInspector] public Dialogue dialogScript;
    // Start is called before the first frame update
    void Start()
    {
        if (portrett != null) {porAni = portrett.GetComponent<Animator>();}
        dialog = GameObject.FindGameObjectWithTag("tekst");
        if (dialog != null) 
        {
            dialogScript = dialog.GetComponent<Dialogue>();
            dialog.SetActive(false);
        }
        interactionText.SetActive(false);
        logikk = GameObject.FindGameObjectWithTag("Logikk");
        logikkScript = logikk.GetComponent<LogikkScript>();
        spiller = GameObject.FindGameObjectWithTag("spiller");
        spillerScript = spiller.GetComponent<Movement>();
        if (itemNummer == 1)
        {
            if (logikkScript.item1PlukketOpp)
            {
                Destroy(gameObject);
            }
        }
        if (itemNummer == 2)
        {
            if (logikkScript.item2PlukketOpp)
            {
                Destroy(gameObject);
            }
        }
        if (itemNummer == 3)
        {
            if (logikkScript.item3PlukketOpp)
            {
                Destroy(gameObject);
            }
        }
        if (itemNummer == 4)
        {
            if (logikkScript.item4PlukketOpp)
            {
                Destroy(gameObject);
            }
        }
        if (itemNummer == 5)
        {
            if (logikkScript.item5PlukketOpp)
            {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (iNoe)
        {
            interactionText.SetActive(true);
            if (itemNummer == 1)
            {
                if (Input.GetButton("Interact"))
                {
                    logikkScript.harItem1 = true;
                    logikkScript.item1PlukketOpp = true;
                    Destroy(interactionText);
                    Destroy(gameObject);
                }
            }
            if (itemNummer == 2)
            {
                if (Input.GetButtonDown("Interact"))
                {

                    if (logikkScript.fornoyd4)
                    {
                        logikkScript.harItem2 = true;
                        logikkScript.item2PlukketOpp = true;
                        Destroy(interactionText);
                        Destroy(gameObject);
                    }
                    else
                    {
                        StartCoroutine(dialog2());
                    }
                }
            }
            if (itemNummer == 3)
            {
                if (Input.GetButton("Interact"))
                {
                    logikkScript.harItem3 = true;
                    logikkScript.item3PlukketOpp = true;
                    Destroy(interactionText);
                    Destroy(gameObject);
                }
            }
            if (itemNummer == 4)
            {
                if (Input.GetButton("Interact"))
                {
                    logikkScript.spillerPosisjon = spiller.transform.position;
                    SceneManager.LoadScene("minigameforsok1");
                }
            }
            if (itemNummer == 5)
            {
                logikkScript.harItem5 = true;
                logikkScript.item5PlukketOpp = true;
                Destroy(interactionText);
                Destroy(gameObject);
            }
        }
        else
        {
            interactionText.SetActive (false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        iNoe = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        iNoe = false;
    }
    IEnumerator dialog2()
    {
        iNoe = false;
        spillerScript.moving = false;
        dialog.SetActive(true);
        portrett.SetActive(true);
        dialogScript.NextLine();
        dialogScript.index = 0;
        porAni.SetInteger("hvilketAnsikt", 31);
        Debug.Log("ja");
        yield return new WaitUntil(() => dialogScript.ferdig == true);
        spillerScript.moving = true;
        dialog.SetActive(false);
        portrett.SetActive(false);
        dialogScript.ferdig = false;
    }
}
