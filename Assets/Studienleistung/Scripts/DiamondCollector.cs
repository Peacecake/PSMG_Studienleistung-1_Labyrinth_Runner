using UnityEngine;
using System.Collections;

public class DiamondCollector : MonoBehaviour {

    GameManager manager;
    AudioSource sound;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        //File Source: http://soundbible.com/1003-Ta-Da.html
        sound = GetComponent<AudioSource>();
    }

	void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            sound.Play();
            manager.GameOverStatus = true;
            Destroy(gameObject, 2f);
        }
    }
}
