using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cultsitScript : MonoBehaviour
{
    [HideInInspector] public GameObject logikk;
    [HideInInspector] public LogikkScript logikkScript;
    [HideInInspector] public GameObject spiller;
    [HideInInspector] public Movement spillerScript;
    bool interact;
    public GameObject interaction;
    public GameObject dialog;
    public Dialogue dialogScript;
    public GameObject portrait;
    public Animator portraitA;


    // Start is called before the first frame update
    void Start()
    {
        spiller = GameObject.FindGameObjectWithTag("spiller");
        spillerScript = spiller.GetComponent<Movement>();
        logikk = GameObject.FindGameObjectWithTag("Logikk");
        logikkScript = logikk.GetComponent<LogikkScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interact)
        {
            if (Input.GetButtonDown("Interact"))
            {
                StartCoroutine(dialogen());
            }
        }
        interaction.SetActive(interact);
        endreAnsikt();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            interact = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
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
    void endreAnsikt()
    {
        if (dialogScript.index == 1) { portraitA.SetInteger("hvilketAnsikt", 60); }
        if (dialogScript.index == 2) { portraitA.SetInteger("hvilketAnsikt", 60); }
        if (dialogScript.index == 3) { portraitA.SetInteger("hvilketAnsikt", 60); }
        if (dialogScript.index == 4) { portraitA.SetInteger("hvilketAnsikt", 60); }

    }
}
