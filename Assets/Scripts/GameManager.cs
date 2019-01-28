using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int playerOneScore;
    int playerTwoScore;
    Vector3 cameraPosition;
    Vector2 screenSize;

    UIManager uiManager;
    DialogueManager dialogueManager;
    public GameObject ballPrefab;
    public GameObject netPrefab;
    public Transform spawnPoint;

    public bool gameOngoing = false;

    public static GameManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }else
        {
            instance = this; 
        }

        
        
        uiManager = FindObjectOfType<UIManager>();
        dialogueManager = FindObjectOfType<DialogueManager>();

        cameraPosition = Camera.main.transform.position;
        screenSize.x = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
        screenSize.y = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;
    }

    public void BeginGame()
    {
        gameOngoing = true;

        playerOneScore = 0;
        playerTwoScore = 0;

        uiManager.UpdatePlayerScore(1, playerOneScore);
        uiManager.UpdatePlayerScore(2, playerTwoScore);

        ViewManager.instance.PlaySetup();
        dialogueManager.StartDialogue();
        dialogueManager.DisplayNextSentence();

        GameObject go = Instantiate(ballPrefab);

        go.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-10, 10));

        spawnPoint.transform.position = new Vector3(cameraPosition.x - screenSize.x, spawnPoint.position.y, 0);
        GameObject net = GameObject.FindGameObjectWithTag("Net");

        net.transform.position = new Vector3(cameraPosition.x + screenSize.x, spawnPoint.position.y, 0);
    }

    public void Score(int player)
    {
        switch (player)
        {
            case 1:
                playerOneScore += 2;
                uiManager.UpdatePlayerScore(1, playerOneScore);
                dialogueManager.PlaySentence("Player 1 Scored!");
                break;
            case 2:
                playerTwoScore += 2;
                uiManager.UpdatePlayerScore(2, playerTwoScore);
                dialogueManager.PlaySentence("Player 2 Scored!");
                break;

            default:
                Debug.LogError("No Player Index Matches :" + player + ".");
                break;

        }
    }

    public void SpawnPlayer2()
    {
        GameObject go = Instantiate(netPrefab, spawnPoint.position, Quaternion.identity);
        go.transform.localScale = new Vector3(-1, 1, 1);

        Hoop hoopManager = go.GetComponentInChildren<Hoop>();


        hoopManager.SetPlayerIndex(2);

    }


    public void QuitGame()
    {
        if (Application.isEditor)
        {
            Debug.Log("Would quit if not in editor.");
        }
        Application.Quit();
    }
}
