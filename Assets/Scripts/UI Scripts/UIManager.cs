using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI scoreTextOne;
    public TextMeshProUGUI scoreTextTwo;
    public TextMeshProUGUI dialogueText;
    public Animator dialogueBoxAnimator;

    public GameObject PlayButton;

    private void Start()
    {
        
    }


    public void UpdatePlayerScore(int index, int score)
    {
        switch (index)
        {
            case 1:
                scoreTextOne.text = "Player 1: " + score;
                break;
            case 2:
                scoreTextTwo.text = "Player 2: " + score;
                break;
            default:
                Debug.LogError("No player index value for :: " + index);
                break;
        }
    }

    public void UpdateDialogueText(string newText)
    {
        
        dialogueBoxAnimator.SetBool("isOpen", true);
        dialogueText.text = newText;
    }

    public void CloseDialogueBox()
    {
        dialogueBoxAnimator.SetBool("isOpen", false);
    }

    public void QuitGame()
    {
        GameManager.instance.QuitGame();
    }


}
