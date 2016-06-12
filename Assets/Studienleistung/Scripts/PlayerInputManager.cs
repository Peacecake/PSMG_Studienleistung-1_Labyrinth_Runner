using UnityEngine;
using System.Collections;

public class PlayerInputManager : MonoBehaviour {

    public float speed = 20f;
    public float rotationSpeed = 40f;

    float inputMovement;
    float inputRotation;
    float speedModifier = 1f;
    Rigidbody rb;
    bool moveable = true;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (moveable)
        {
            move();
            rotate();
        }
	}

    void move()
    {
        inputMovement = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * speed * inputMovement * Time.deltaTime * speedModifier;
        rb.MovePosition(rb.position + movement);
    }

    void rotate()
    {
        inputRotation = Input.GetAxis("Horizontal");
        float turn = inputRotation * rotationSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    public void setMoveable(bool newBool)
    {
        moveable = newBool;
    }

    public void reduceSpeed(float reduceVal)
    {
        speedModifier = reduceVal;
    }
}
