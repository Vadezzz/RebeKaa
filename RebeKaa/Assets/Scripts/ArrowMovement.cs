using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{

    private Vector3 position;
    public GameObject bodyPrefab;
    List<GameObject> body;

    // Start is called before the first frame update
    void Start()
    {
        body = new List<GameObject>();
        body.Add(this.gameObject);
    }

    // Update is called once per frame

    void Update() {
        int horizontalDir = Math.Sign(Input.GetAxis("Horizontal"));
        int verticalDir = Math.Sign(Input.GetAxis("Vertical"));

        //unidad de movimiento
        float magnitude = 1;

        if (horizontalDir != 0) {
            position = magnitude*horizontalDir*Vector3.right;
        } else if (verticalDir != 0) {
            position = magnitude*verticalDir*Vector3.up;
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
        Debug.Log("Hay " + body.Count + " segmentos");
        this.transform.position += position;
        
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

