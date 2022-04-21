using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 0.5f;
    SpriteRenderer  spriteRenderer;
    public Collider2D slimeCollider;
    readonly public int damage = 5;
    public bool Deafeatedcalled = false;
    public SwordAttack swrd;
    
    readonly public float KnockMultiplier = 1.5f;
    

    private void Start(){
        animator = GetComponent<Animator>();
        rb=this.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        slimeCollider = GetComponent<Collider2D>();
    }
    void Update (){
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction; 
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        if (direction.x <= 0 ){
            spriteRenderer.flipX = true;
        }
        else {
            spriteRenderer.flipX = false;
        }  

    }
    public float Health{
        set{
            health = value;
            if(health <= 0){
                Deafeated();
            }
        }
        get{
            return health;
        }
    }
    public float health = 5;

    public void Deafeated(){
        Deafeatedcalled = true;
        slimeCollider.enabled = !slimeCollider.enabled;
        animator.SetTrigger("Defeated");
    }
    public void RemoveEnemy(){
        Destroy(gameObject);
    }

    public void KnockbackFrom(Transform force) {
        transform.position += (transform.position - force.position) * KnockMultiplier;         
        }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "sword"){
            health = health - swrd.damage;
            animator.SetTrigger("damage");
        }
    }
}

