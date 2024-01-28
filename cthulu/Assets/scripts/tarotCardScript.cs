using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tarotCardScript : MonoBehaviour
{
    bool valgt;
    bool tatt;
    Vector3 hvor;
    Animator a;
    public int hvilken;
    [HideInInspector] public GameObject logikk;
    [HideInInspector] public LogikkScript logikkScript;
    public AudioSource au;
    public AudioSource au2;
    // Start is called before the first frame update
    void Start()
    {
        logikk = GameObject.FindGameObjectWithTag("Logikk");
        logikkScript = logikk.GetComponent<LogikkScript>();
        hvor = transform.position;
        a = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (valgt)
        {
            if (Input.GetButtonDown("Interact"))
            {
                tatt = true;
                au.Play();
            }
        }
        if (tatt && hvor.y <6)
        {
            hvor.y = hvor.y +5 *Time.deltaTime;
            transform.position = hvor;
        }
        else if (hvor.y >=6) 
        {
            StartCoroutine(snuKortet());
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        valgt = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        valgt = false;
    }
    IEnumerator snuKortet()
    {
        tatt = false;
        hvor.y = 0;
        a.SetInteger("snu", hvilken);
        transform.position = hvor;
        au2.Play();
        logikkScript.spillerPosisjon = new Vector3 (-0.3f,0.3f,-2);
        logikkScript.tarotDialog = true;
        logikkScript.hvilkenTarrot = hvilken;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("hippie");
    }
}
