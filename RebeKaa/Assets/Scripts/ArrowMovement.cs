using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{

    private Vector3 position;
    private int rotationTrigger;
    public GameObject bodyPrefab;
    List<GameObject> body;
    private int currentHorizDir;
    private int currentVertDir;

    // Start is called before the first frame update
    void Start()
    {
        body = new List<GameObject>();
        body.Add(this.gameObject);
        currentHorizDir = 0;
        currentVertDir = 0;
    }

    // Update is called once per frame

    void Update() {
        int horizontalDir = Math.Sign(Input.GetAxis("Horizontal"));
        int verticalDir = Math.Sign(Input.GetAxis("Vertical"));

        //unidad de movimiento
        float magnitude = 1;

        if (horizontalDir != 0 && currentHorizDir == 0) {
            position = magnitude*horizontalDir*Vector3.right;
            rotationTrigger = 1;
            currentHorizDir = horizontalDir;
            currentVertDir = 0;
        } else if (verticalDir != 0 && currentVertDir == 0) {
            position = magnitude*verticalDir*Vector3.up;
            rotationTrigger = 1;
            currentVertDir = verticalDir;
            currentHorizDir = 0;
            //transform.Translate(0,movement*Time.deltaTime,0);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            makeBigger();
        }

    }
    void FixedUpdate()
    {
        /*
        for (int i = 1; i < body.Count; i++) {
            body[i].transform.position = body[i-1].transform.position;
        }
        */
        for(int i = body.Count - 1; i > 0; i--) {
            body[i].transform.position = body[i-1].transform.position;
        }

        this.transform.position += position;
        if(rotationTrigger != 0) {
            if (currentHorizDir != 0) {
                transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
                transform.localScale = new Vector3(1,-currentHorizDir,1);
            } else {
                transform.rotation = Quaternion.Euler(new Vector3(0,0,-180));
                transform.localScale = new Vector3(1,-currentVertDir,1);
            }
            rotationTrigger = 0;
        }
    }

    private void makeBigger() {
        Vector3 pos = body[body.Count-1].transform.position;
        Debug.Log("posicion: " + pos.ToString());
        GameObject newSegment = Instantiate(bodyPrefab,pos,Quaternion.identity);
        body.Add(newSegment);
        //body.Insert(body.Count-1,newSegment);
        //body.AddLast(newSegment);
    }

    private void makeSmaller() {
        //body.RemoveLast();
    }

    //falta que si estas yendo hacia una direccion, no te permita ir hacia dicha direccion
    
}

