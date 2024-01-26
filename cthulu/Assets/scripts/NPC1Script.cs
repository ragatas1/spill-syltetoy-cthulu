using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC1Script : MonoBehaviour
{
    GameObject spiller;
    Movement spillerScript;
    public bool harItem;
    public GameObject text;
    public GameObject son;
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        spiller = GameObject.FindGameObjectWithTag("spiller");
        spillerScript = spiller.GetComponent<Movement>();
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
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (spillerScript.harItem1 == true)
        {
            text.SetActive(true);
            if (Input.GetButton("Interact"))
            {
                harItem = true;
                spillerScript.itemCount = 0;
                spillerScript.harItem1 = false;
            }
        }
        else
        {
            text.SetActive(false) ;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        text.SetActive(false);
    }
}
