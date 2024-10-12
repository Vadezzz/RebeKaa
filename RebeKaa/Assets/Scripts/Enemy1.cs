<<<<<<< Updated upstream
=======
using System;
>>>>>>> Stashed changes
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
<<<<<<< Updated upstream
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 5.0f;
    public float travelDistance = 10f;
    private Rigidbody _rigid;
    private Vector3 movementDirection;
    private bool isStopping = false;
    public float stopTime = 1.0f; // time to stop before rotating
    private float distanceTraveled = 0f;
=======
    public float movementSpeed = 3f;
    public float rotationSpeed = 5.0f;
    public float travelDistance = 20f;
    private Rigidbody2D _rigid;
    private Vector2 movementDirection;
    private bool isStopping = false;
    public float stopTime = 1.0f; // time to stop before rotating
    private float distanceTraveled = 0f;
	Vector2 direction = Vector2.right;
    public bool horizontal;


>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
        _rigid = GetComponent<Rigidbody>();
        movementDirection = transform.forward;
=======
        _rigid = GetComponent<Rigidbody2D>();
        movementDirection = transform.forward;
        direction = horizontal ? Vector2.right : Vector2.down;

>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStopping)
        {
            // move the character continuously
<<<<<<< Updated upstream
            _rigid.MovePosition(transform.position + movementDirection * movementSpeed * Time.deltaTime);
=======
		    _rigid.MovePosition(_rigid.position + direction * movementSpeed * Time.deltaTime);
>>>>>>> Stashed changes
            distanceTraveled += movementSpeed * Time.deltaTime;
            // check if distance traveled exceeds travel distance
            if (distanceTraveled >= travelDistance)
            {
                isStopping = true;
            }
        }
        else
        {
            // stop the character for a moment
<<<<<<< Updated upstream
            _rigid.velocity = Vector3.zero;
            _rigid.angularVelocity = Vector3.zero;
            // rotate the character
            Quaternion targetRotation = Quaternion.Euler(0, 90, 0); // rotate 90 degrees
            _rigid.MoveRotation(Quaternion.Lerp(_rigid.rotation, targetRotation, rotationSpeed * Time.deltaTime));
=======
            //_rigid.velocity = Vector2.zero;
            // rotate the character
            //int rand = UnityEngine.Random.Range(1,4);
            //float targetRotation = rand*90f; // rotate 90 degrees
            //float rotation = Mathf.LerpAngle(_rigid.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            //_rigid.MoveRotation(rotation);
            horizontal = !horizontal;
            direction = horizontal ? Vector2.right : Vector2.down;

>>>>>>> Stashed changes

            // wait for a moment before continuing
            stopTime -= Time.deltaTime;
            if (stopTime <= 0)
            {
                isStopping = false;
                stopTime = 1.0f;
            }
        }
    }

    private void OnCollisionEnter(Collision collision){
       
    }
}
