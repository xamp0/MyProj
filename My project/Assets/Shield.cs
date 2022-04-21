using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float nearEnough = 0.2f;
    public playercontroller player;
    public Transform shieldPos;
    public Transform playerPos;
    void Start()
    {
        
    }

    void Update()
    {
        if (Vector2.Distance(shieldPos.transform.position, playerPos.transform.position) < nearEnough)
        {
            player.PlayerArmor += 10;
            Destroy(gameObject);
        }

    }
}
