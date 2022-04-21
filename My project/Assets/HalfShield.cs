using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfShield : MonoBehaviour
{
    public float nearEnough = 0.2f;
    public playercontroller player;
    public Transform HalfshieldPos;
    public Transform playerPos;
    void Start()
    {

    }

    void Update()
    {
        if (Vector2.Distance(HalfshieldPos.transform.position, playerPos.transform.position) < nearEnough)
        {
            player.PlayerArmor += 5;
            Destroy(gameObject);
        }

    }
}
