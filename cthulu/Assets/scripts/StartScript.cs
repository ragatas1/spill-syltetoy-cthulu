using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public Dialogue script;
    // Update is called once per frame
    void Update()
    {
        if (script.index == script.lines.Length-1)
        {
            SceneManager.LoadScene("Em");
        }
    }
}
