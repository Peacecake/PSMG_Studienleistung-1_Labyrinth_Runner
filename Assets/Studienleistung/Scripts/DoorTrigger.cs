using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {

    Door thisDoor;
    AudioSource bingSound;
    UIController uiController;

    bool triggerEntered;

	// Use this for initialization
	void Start ()
    {
        //File Source: http://soundbible.com/1441-Elevator-Ding.html
        bingSound = GetComponent<AudioSource>();
        thisDoor = transform.parent.parent.GetComponentInChildren<Door>();
        uiController = GameObject.FindGameObjectWithTag("UserInterface").GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update () {
        if (triggerEntered)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(thisDoor.OpenStatus == false)
                {
                    thisDoor.OpenStatus = true;
                }
                else
                {
                    thisDoor.OpenStatus = false;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        triggerEntered = true;
        uiController.showOpenText(triggerEntered);
        bingSound.Play();
    }

    void OnTriggerExit(Collider other)
    {
        triggerEntered = false;
        uiController.showOpenText(triggerEntered);
    }
}
