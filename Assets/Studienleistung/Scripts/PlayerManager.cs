using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    int healthPoints;
    float speedReduce;

    PlayerInputManager inputManager;
    GameManager gameManager;

	// Use this for initialization
	void Start ()
    {
        inputManager = GetComponent<PlayerInputManager>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        healthPoints = 100;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(healthPoints < 100)
        {
            speedReduce = (float)healthPoints / 100;
            inputManager.reduceSpeed(speedReduce);
        }
        if(healthPoints <= 0)
        {
            gameManager.GameOverStatus = true;
        }
	}

    public int HealthPoint
    {
        get
        {
            return healthPoints;
        }
        set
        {
            healthPoints = value;
        }
    } 
}
