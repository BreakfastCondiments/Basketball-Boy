using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Button : MonoBehaviour
{
    public GameObject scoreText;

    public void SpawnPlayerTwo()
    {
        Debug.Log("Player 2 spawned. Yet to be implimented.");
        ViewManager.instance.ShowView(scoreText);
        ViewManager.instance.HideView(gameObject);
        GameManager.instance.SpawnPlayer2();
    }
}
