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
    public GameObject dialog;
    public Dialogue dialogScript;
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
    }

    // Update is called once per frame
    void Update()
    {
        interactionText.SetActive(iNoe);
        if (iNoe)
        {

            if (itemNummer == 1)
            {
                if (Input.GetButton("Interact"))
                {
                    logikkScript.harItem1 = true;
                    logikkScript.item1PlukketOpp = true;
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
                        Destroy(gameObject);
                    }
                    else
                    {
                        StartCoroutine(dialog2());
                    }
                }
            }
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
