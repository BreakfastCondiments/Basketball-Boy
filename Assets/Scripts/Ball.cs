using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{




    private void Start()
    {
        //needs to be changed to queue
       
    }

    void PlayMessage(string messageToPlay)
    {
        Debug.Log(messageToPlay);
    }

    public void Clicked()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }


}



