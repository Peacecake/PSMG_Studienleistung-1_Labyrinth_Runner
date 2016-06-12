using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Transform spawnpoint;
    public GameObject player;

    PlayerInputManager inputManager;
    UIController uiController;

    bool gameover;

    public bool GameOverStatus
    {
        get
        {
            return gameover;
        }
        set
        {
            gameover = value;
        }
    }

	// Use this for initialization
	void Start ()
    {
        GameObject obj = Instantiate(player, spawnpoint.position, spawnpoint.rotation) as GameObject;
        inputManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputManager>();
        uiController = GameObject.FindGameObjectWithTag("UserInterface").GetComponent<UIController>();

        gameover = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        checkForGameOver();
	}

    void checkForGameOver()
    {
        if(gameover)
        {
            inputManager.setMoveable(false);
            uiController.showGameOverText();

            StartCoroutine(RestartGame());
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(5);
        Application.LoadLevel(Application.loadedLevel);
    }
}
