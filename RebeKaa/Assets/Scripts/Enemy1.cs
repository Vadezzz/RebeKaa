using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy1 : MonoBehaviour{
    public float speed = 5f;  // Velocidad de movimiento
    public float rotationSpeed = 90f;  // Velocidad de rotación en grados por segundo
    private Vector2 moveDirection;  // Dirección de movimiento en 2D
    private float currentRotation = 0f;  // Ángulo actual de rotación en grados
    private float xBorderLimit, yBorderLimit;
    public float rotationInterval = 2f;  // Intervalo de rotación en segundos
    private float timeSinceLastRotation;


    void Start()
    {
        // Inicializar la dirección de movimiento como hacia arriba (0 grados)
        moveDirection = Vector2.up;
        xBorderLimit = Camera.main.orthographicSize+1;
        yBorderLimit = (Camera.main.orthographicSize+1)* Screen.width / Screen.height;
    }

    void Update()
    {
        // Mover el enemigo en la dirección de movimiento
        transform.position += (Vector3)moveDirection * speed * Time.deltaTime;

        // Ejemplo: rotar el enemigo cuando presionamos la barra espaciadora
        timeSinceLastRotation += Time.deltaTime;
        if (timeSinceLastRotation >= rotationInterval)
        {
            RotateEnemy();
            timeSinceLastRotation = 0f;
        }
        var newPos = transform.position;
        if(newPos.x > xBorderLimit)
        newPos.x = -xBorderLimit+1;
        else if(newPos.x < -xBorderLimit)
        newPos.x = xBorderLimit-1;
        else if(newPos.y > yBorderLimit)
        newPos.y = -yBorderLimit+1;
        else if(newPos.y < -yBorderLimit)
        newPos.y = yBorderLimit-1;
        transform.position = newPos;
    }

    void RotateEnemy()
    {
        // Rotar al enemigo un ángulo aleatorio
        int randomAngle = UnityEngine.Random.Range(0, 3);
        currentRotation = (randomAngle*90f)%360f;
        
        // Mantener la rotación dentro de los 360 grados
        //if (currentRotation >= 360f) currentRotation -= 360f;

        // Aplicar la rotación al transform
        Vector3 aux = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y, currentRotation);
        Quaternion q = new Quaternion();
        q.eulerAngles = aux;
        transform.rotation = q;
        print(currentRotation);

        // Actualizar la dirección de movimiento según el ángulo de rotación actual
        float radians = currentRotation * Mathf.Deg2Rad;
        if(currentRotation == 0){
            moveDirection = new Vector2(0,1);
        }
        else if(currentRotation == 90){
            moveDirection = new Vector2(-1,0);
        }
        else if(currentRotation == 180){
            moveDirection = new Vector2(0,-1);
        }
        else if(currentRotation == 270){
            moveDirection = new Vector2(1,0);
        }
        print(moveDirection);
    }
}
