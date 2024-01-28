using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogikkScript : MonoBehaviour
{    
    public bool harItem1;
    public bool fornoyd1;
    public bool fornoyd2;
    public bool fornoyd3;
    public bool fornoyd4;
    public bool fornoyd5;
    public int hjerteCounter;
    public bool item1PlukketOpp;
    public bool item2PlukketOpp;
    public bool harItem2;
    public bool item3PlukketOpp;
    public bool harItem3;
    public bool item4PlukketOpp;
    public bool harItem4;
    public bool item5PlukketOpp;
    public bool harItem5;
    public Vector3 spillerPosisjon;
    public float startY;
    public float startX;
    public bool father;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        spillerPosisjon = new Vector3(startX,startY,-2);
        father = false;
    }
    

    // Update is called once per frame
    void Update()
    {
        if(hjerteCounter >= 5)
        {
            Scene currentScene = SceneManager.GetActiveScene();

            string sceneName = currentScene.name;

            if (sceneName == "ute")
            {
                father = true;
            }
        }
    }
}
