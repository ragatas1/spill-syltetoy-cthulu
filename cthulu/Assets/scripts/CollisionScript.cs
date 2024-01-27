using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    [HideInInspector] public bool colided;
    private void OnTriggerStay2D(Collider2D collision)
    {
        colided = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        colided= false;
    }
}
