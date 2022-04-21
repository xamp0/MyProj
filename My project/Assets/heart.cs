using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    public float nearEnough = 0.2f;
    public playercontroller player;
    public Transform heartPos;
    public Transform playerPos;
    void Start()
    {
       
    }
    void FixedUpdate()
    {
        if (Vector2.Distance(heartPos.transform.position, playerPos.transform.position) < nearEnough)
        {
            player.PlayerHealth += 10;
            Destroy(gameObject);
        }
    }


}
