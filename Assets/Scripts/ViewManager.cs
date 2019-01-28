using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    public static ViewManager instance { get; set; }

    
    UIManager uiManager;
    public GameObject ingameView, dialogueBox;

    private void OnEnable()
    {
        instance = this;
        uiManager = FindObjectOfType<UIManager>();
        
    }

    private void Start()
    {
        HideView(ingameView);
    }


    public void PlaySetup()
    {
        ShowView(ingameView);
        HideView(uiManager.scoreTextTwo.gameObject);
        
    }

    public void HideView(GameObject toHide)
    {
        toHide.SetActive(false);
    }

    public void ShowView(GameObject toShow)
    {
        toShow.SetActive(true);
    }



}
