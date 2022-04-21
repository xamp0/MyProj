using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour{
    public Collider2D swordCollider;
    Vector2 rightattackOffset;
    public float damage = 3;

    void Start(){
        rightattackOffset = transform.position;
    }
    public void AttackRight (){
        //print("attack right");
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(rightattackOffset.x, rightattackOffset.y);
    }

    public void AttackLeft (){
        //print("attack lft");
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(rightattackOffset.x * -1 , rightattackOffset.y);
    }

    public void StopAttack (){
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other){
       if(other.tag == "Enemy"){
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.KnockbackFrom(transform);
            if(enemy!=null){
                enemy.Health -= damage;
            }
        }
    }
}


