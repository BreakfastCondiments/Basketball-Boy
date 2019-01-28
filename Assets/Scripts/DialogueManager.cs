using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    Queue<string> sentencesPending;
    UIManager uiManager;

    public Dialogue turorialMessages;

    public Dialogue randomMessages;

    float dialogueFadeTime = 5f;
    bool isDialogueOpen = false;

   

    // Start is called before the first frame update
    void Start()
    {
        sentencesPending = new Queue<string>();

        uiManager = FindObjectOfType<UIManager>();
    }


    public void StartDialogue()
    {
        Debug.Log("Starting Dialogue.");

        sentencesPending.Clear();

        foreach(string sentence in turorialMessages.sentences)
        {
            sentencesPending.Enqueue(sentence);
        }

        
    }

    public void DisplayNextSentence()
    {
        string sentence;

        if(sentencesPending.Count == 0)
        {

            sentence = randomMessages.sentences[Random.Range(0, randomMessages.sentences.Length)];
        }
        else
        {
            sentence = sentencesPending.Dequeue();
        }


        PlaySentence(sentence);

        
    }

    public void PlaySentence(string sentence)
    {
        
        uiManager.UpdateDialogueText(sentence);

        if (!isDialogueOpen)
            StartCoroutine(CloseBoxLatency());
        else
            dialogueFadeTime = 3f;
    }

    IEnumerator CloseBoxLatency()
    {
        Debug.Log("Dialogue Box countdown started.");
        isDialogueOpen = true;
        while (dialogueFadeTime > 0)
        {
            dialogueFadeTime -= Time.deltaTime;
            yield return null;
        }
        EndDialogue();
        isDialogueOpen = false;
        dialogueFadeTime = 3f;
    }

    void EndDialogue()
    {
        
        uiManager.CloseDialogueBox();
    }

}
