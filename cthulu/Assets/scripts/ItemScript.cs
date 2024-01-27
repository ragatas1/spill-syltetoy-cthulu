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
    bool iNoe;
    public GameObject interactionText;
    // Start is called before the first frame update
    void Start()
    {
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
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        interactionText.SetActive(true);
        iNoe = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactionText.SetActive(false);
        iNoe = false;
    }
}
