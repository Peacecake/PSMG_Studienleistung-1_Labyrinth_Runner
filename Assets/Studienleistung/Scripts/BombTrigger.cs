using UnityEngine;
using System.Collections;

public class BombTrigger : MonoBehaviour {

    AudioSource bombExplosion;
    PlayerManager playerManager;

	// Use this for initialization
	void Start ()
    {
        //File Source: http://soundbible.com/1234-Bomb.html
        bombExplosion = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();

        if (other.tag == "Player")
        {
            bombExplosion.Play();
            playerManager.HealthPoint -= 20;
            Destroy(gameObject, 2.0f);
        }
    }
}
