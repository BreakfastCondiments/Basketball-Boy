using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public void BeginGame()
    {
        GameManager.instance.BeginGame();
        ViewManager.instance.HideView(gameObject);
    }
}
