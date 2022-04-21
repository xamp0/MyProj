using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armorbar : MonoBehaviour
{
    public GameObject heart1 = GameObject.Find("shield1");
    public GameObject heart2 = GameObject.Find("shield2");
    public GameObject heart3 = GameObject.Find("shield3");
    public GameObject heart4 = GameObject.Find("shield4");
    public GameObject heart5 = GameObject.Find("shield5");
    public GameObject FF5 = GameObject.Find("FF5");
    public GameObject FF4 = GameObject.Find("FF4");
    public GameObject FF3 = GameObject.Find("FF3");
    public GameObject FF2 = GameObject.Find("FF2");
    public GameObject FF1 = GameObject.Find("FF1");
    public playercontroller player;
    private int health;

    void FixedUpdate()
    {
        health = player.PlayerArmor;
        if (health > 0)
        {
            FF1.SetActive(true);
            heart1.SetActive(true);
            //if (health <= 0) { heart1.SetActive(true); }
            if (health <= 5) { FF1.SetActive(false); }
            if (health >= 11)
            {
                FF2.SetActive(true);
                if (health <= 15) { FF2.SetActive(false); }
                heart2.SetActive(true);
                if (health >= 21)
                {
                    FF3.SetActive(true);
                    if (health <= 25) { FF3.SetActive(false); }
                    heart3.SetActive(true);
                    if (health >= 31)
                    {
                        FF4.SetActive(true);
                        if (health <= 35) { FF4.SetActive(false); }
                        heart4.SetActive(true);
                        if (health >= 41)
                        {
                            FF5.SetActive(true);
                            heart5.SetActive(true);
                            if (health <= 45) { FF5.SetActive(false); }
                            else { heart5.SetActive(false); }
                        }
                    }
                    else
                    {
                        heart4.SetActive(false);
                        heart5.SetActive(false);
                    }
                }
                else
                {
                    heart3.SetActive(false);
                    heart4.SetActive(false);
                    heart5.SetActive(false);

                }
            }
            else
            {
                heart2.SetActive(false);
                heart3.SetActive(false);
                heart4.SetActive(false);
                heart5.SetActive(false);
            }
        }
        else
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }
    }
}
