using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 5.0f;
    public float travelDistance = 10f;
    private Rigidbody _rigid;
    private Vector3 movementDirection;
    private bool isStopping = false;
    public float stopTime = 1.0f; // time to stop before rotating
    private float distanceTraveled = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        movementDirection = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStopping)
        {
            // move the character continuously
            _rigid.MovePosition(transform.position + movementDirection * movementSpeed * Time.deltaTime);
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
            _rigid.velocity = Vector3.zero;
            _rigid.angularVelocity = Vector3.zero;
            // rotate the character
            Quaternion targetRotation = Quaternion.Euler(0, 90, 0); // rotate 90 degrees
            _rigid.MoveRotation(Quaternion.Lerp(_rigid.rotation, targetRotation, rotationSpeed * Time.deltaTime));

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
