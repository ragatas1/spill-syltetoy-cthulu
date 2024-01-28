using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;

    public string[] lines;

    public float textSpeed;
    public int index;
    [HideInInspector] public bool ferdig;
    public GameObject Au1;
    public AudioSource au1;
    public GameObject Au2;
    public AudioSource au2;
    public int au;
    int fix;
    public int soundspeed = 2;
    // Start is called before the first frame update
    void Awake()
    {
        textComponent.text = string.Empty;
        StartDialogue();
        Au1 = GameObject.FindGameObjectWithTag("au1");
        au1 = Au1.GetComponent<AudioSource>();
        Au2 = GameObject.FindGameObjectWithTag("au2");
        au2 = Au2.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            // Is text fully displayed? Go to next line
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
            if (fix == 0)
            {
                au = Random.Range(1, 3);
                if (au == 1)
                {
                    au1.Play();
                }
                else if (au == 2)
                {
                    au2.Play();
                }
                fix = soundspeed;
            }
            else { fix = fix-1; }
        }
    }

    public void NextLine()
    {
        if (index < lines.Length-1 )
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            ferdig = true;
            textComponent.text = string.Empty;
        }
    }
}
