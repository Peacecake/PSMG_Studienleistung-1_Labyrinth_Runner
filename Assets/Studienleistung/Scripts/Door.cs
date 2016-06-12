using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    AudioSource openingSound;
    bool isOpen;

    float doorClosedPos = 3f;
    float doorOpenedPos = 1.5f;

    public bool OpenStatus
    {
        get
        {
            return isOpen;
        }
        set
        {
            isOpen = value;
        }
    }
	
    void Start()
    {
        //File Source: http://soundbible.com/1353-Sliding-Door.html
        openingSound = GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update ()
    {
        if (isOpen)
        {
            changeDoorPosition(doorOpenedPos);
        }
        else
        {
            changeDoorPosition(doorClosedPos);
        }
	}

    void changeDoorPosition(float newPosition)
    {
        if (transform.position.y > newPosition && isOpen)
        {
            Vector3 position = new Vector3(0, -newPosition, 0);
            transform.Translate(position * Time.deltaTime, Space.World);
        }
        if (transform.position.y  < newPosition && !isOpen)
        {
            Vector3 position = new Vector3(0, newPosition, 0);
            transform.Translate(position * Time.deltaTime, Space.World);
        }
    }
}
