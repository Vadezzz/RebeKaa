using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab1; //lagarto
    public GameObject enemyPrefab2; //aguila
    
    //public GameObject enemyPrefab3; //fenec
    //public GameObject snakeHead; 
    //private int xlimit = 33;
    //private int ylimit = 14;
    private int waveCounter = 1;
    public int timeBetweenWaves = 30;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnWave",0f,timeBetweenWaves);
    }

    // private void spawnRandomEnemy(GameObject enemy) {
    //     int x,y;
    //     do{
    //         x = UnityEngine.Random.Range(-xlimit,xlimit);
    //         y = UnityEngine.Random.Range(-ylimit,ylimit);
    //     } while(distanceLessThan(snakeHead.transform.position,x,y));
    //     GameObject e1 = Instantiate(enemy, new Vector3(x,y,0), Quaternion.identity);
    //     e1.transform.localScale = new Vector3(2,2,2);
    // }

    private void spawnWave(){
        switch (waveCounter){
            case 1:
                wave1();
                waveCounter++;
                break;
            case 2:
                wave2();
                waveCounter++;
                timeBetweenWaves += 30;
                break;
            case 3:
                wave3();
                waveCounter++;
                CancelInvoke();
                break;
            default:
                break;
        }
    }

    private void wave1(){
        int x1,y1,x2,y2,x3,y3;
        x1 = -13; y1 = 0;
        x2 = 13; y2 = 0;
        x3 = 0; y3 = 10;
        Vector3 pos1 = new Vector3(x1,y1,0);
        Vector3 pos2 = new Vector3(x2,y2,0);
        Vector3 pos3 = new Vector3(x3,y3,0);
        GameObject e1 = Instantiate(enemyPrefab1, pos1, Quaternion.identity);
        e1.transform.localScale = new Vector3(2,2,2);
        GameObject e2 = Instantiate(enemyPrefab1, pos2, Quaternion.identity);
        e2.transform.localScale = new Vector3(2,2,2);
        GameObject e3 = Instantiate(enemyPrefab1, pos3, Quaternion.identity);
        e3.transform.localScale = new Vector3(2,2,2);
        //spawnRandomEnemy(enemyPrefab1);
    }
    private void wave2(){
        int x1,y1,x2,y2;
        x1 = -13; y1 = 0;
        x2 = 13; y2 = 0;
        Vector3 pos1 = new Vector3(x1,y1,0);
        Vector3 pos2 = new Vector3(x2,y2,0);
        GameObject e1 = Instantiate(enemyPrefab2, pos1, Quaternion.identity);
        e1.transform.localScale = new Vector3(2,2,2);
        GameObject e2 = Instantiate(enemyPrefab2, pos2, Quaternion.identity);
        e2.transform.localScale = new Vector3(2,2,2);
        //spawnRandomEnemy(enemyPrefab1);
        //spawnRandomEnemy(enemyPrefab1);
    }

    private void wave3(){
        
    }

    private bool distanceLessThan(Vector3 pos1, int x2, int y2){ 
        //Por si se quiere spawnear enemigos alejados del jugador
        float x1 = pos1.x;
        float y1 = pos1.y;
        return (Math.Sqrt(Math.Pow(x2-x1,2) +
                    Math.Pow(y2-y1,2)) < 8) ? true : false;
    }
}
