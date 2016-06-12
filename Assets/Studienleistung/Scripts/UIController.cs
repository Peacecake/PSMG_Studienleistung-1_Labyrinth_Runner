using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text playerHealthText;
    public Text gameOverText;
    public Text timeText;
    public Text openText;

    PlayerManager playerManager;
    bool playerDead;

	// Use this for initialization
	void Start ()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        gameOverText.text = "";
        openText.text = "";
	}
	
	// Update is called once per frame
	void Update ()
    {
        showHealth();
        showTime();
	}

    void showHealth()
    {
        playerHealthText.text = "Health: " + playerManager.HealthPoint;
    }

    void showTime()
    {
        int minutes = (int)Time.time / 60;
        int seconds = (int)Time.time % 60;  //source: http://answers.unity3d.com/questions/200733/timetime-as-minutes-and-seconds-.html
        timeText.text =minutes + ":" + seconds;
    }

    public void showGameOverText()
    {
        gameOverText.text = "GAME OVER!";
    }


    public void showOpenText(bool triggerEntered)
    {
        if (triggerEntered)
        {
            openText.text = "Press 'Space' to open";
        }
        else
        {
            openText.text = "";
        }
    }
}
