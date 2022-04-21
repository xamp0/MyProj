using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] UpRooms;
    public GameObject[] BottomRooms;
    public GameObject[] RightRooms;
    public GameObject[] LeftRooms;
    public GameObject ClosedRoom;
    public int spawnedSize;
    public List<GameObject> rooms;
    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;
    private void Update()
    {
        if (waitTime <= 0 && spawnedBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count - 1)
                {
                    Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                    spawnedBoss = true;
                }
            }
        }else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
