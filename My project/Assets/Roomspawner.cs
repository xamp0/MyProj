using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomspawner : MonoBehaviour
{
    public int OpenDir;
    //1-top
    //2-bottom
    //3-right
    //4-left
    private int rand;
    private bool spawned;
    private RoomTemplates templates;
    public int MaxSpawned = 15;
    public float waitTime = 4f;
    void Awake(){
        Destroy(gameObject, waitTime);
        templates = GameObject.FindWithTag("RoomTemplate").GetComponent<RoomTemplates>();
        Invoke("Spawn", 2f);       
    }

    void Spawn()    
    {
        if (spawned == false){
            if (OpenDir == 2)
            {
                if (templates.spawnedSize >= MaxSpawned) { rand = 1; }
                else
                { rand = Random.Range(0, templates.UpRooms.Length); templates.spawnedSize++; }
                Instantiate(templates.UpRooms[rand], transform.position, templates.UpRooms[rand].transform.rotation);
            }
            else if (OpenDir == 1) 
            {
                if (templates.spawnedSize >= MaxSpawned) { rand = 1; }else 
                { rand = Random.Range(0, templates.BottomRooms.Length); templates.spawnedSize++; }
                Instantiate(templates.BottomRooms[rand], transform.position, templates.BottomRooms[rand].transform.rotation);
            }
            else if (OpenDir == 4) 
            {
                if (templates.spawnedSize >= MaxSpawned) { rand = 1; }
                else
                { rand = Random.Range(0, templates.RightRooms.Length); templates.spawnedSize++; }
                Instantiate(templates.RightRooms[rand], transform.position, templates.RightRooms[rand].transform.rotation);
            }
            else if (OpenDir == 3) 
            {
                if (templates.spawnedSize >= MaxSpawned) { rand = 1; }
                else
                { rand = Random.Range(0, templates.LeftRooms.Length); templates.spawnedSize++; }
                Instantiate(templates.LeftRooms[rand], transform.position, templates.LeftRooms[rand].transform.rotation);
            }
            spawned = true;
        }   
    }
    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("RoomSP")){
            if(other.GetComponent<Roomspawner>().spawned == false && spawned == false) {
                Instantiate(templates.ClosedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

    }
    void FixedUpdate() {
        //print(templates.spawnedSize);
    }

}
