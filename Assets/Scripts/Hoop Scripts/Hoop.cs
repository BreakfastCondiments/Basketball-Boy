using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    bool checkingScore;
    int playerIndex = 1;
    public SpriteRenderer hoopSprite;

    public HoopTriggerBox top;
    public HoopTriggerBox bottom;
    



    private void Update()
    {
        if (checkingScore)
            return;

        if (top.ballIsHere && !bottom.ballIsHere)
            StartCoroutine(PossibleScore());
    }


    IEnumerator PossibleScore()
    {
        checkingScore = true;
        Debug.Log("Possible Score.");
        while (top.ballIsHere && checkingScore)
        {
            if (bottom.ballIsHere)
            {
                GameManager.instance.Score(playerIndex);
                checkingScore = false;
            }
            yield return null;
        }

        checkingScore = false;
    }

    public void SetPlayerIndex(int newIndex)
    {
        playerIndex = newIndex;
    }

   public void SetHoopColour(Color colour)
    {
        hoopSprite.color = colour;
    }
}
