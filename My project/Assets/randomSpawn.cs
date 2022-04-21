using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawn : MonoBehaviour
{
    
    public Transform [] spawnPoints;
    public GameObject[] enemy;
    
    void Start(){
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy[0], spawnPoints[randSpawnPoint].position, transform.rotation);
        }
    }
    public void spawnenemy(){
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy[0], spawnPoints[randSpawnPoint].position, transform.rotation);
    }
}
