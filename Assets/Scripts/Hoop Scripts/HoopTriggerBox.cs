using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopTriggerBox : MonoBehaviour
{
    public bool ballIsHere;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ballIsHere = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ballIsHere = false;
    }
}
