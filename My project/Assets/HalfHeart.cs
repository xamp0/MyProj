using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfHeart : MonoBehaviour
{ 
public playercontroller player;
    public float nearEnough = 0.2f;
    public Transform HalfHeartPos;
    public Transform playerPos;
    void Start()
    {   

    }
    void FixedUpdate()
    {
        if (Vector2.Distance(HalfHeartPos.transform.position, playerPos.transform.position) < nearEnough)
        {
            player.PlayerHealth += 5;
            Destroy(gameObject);
        }
    }
}

