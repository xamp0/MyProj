using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public SwordAttack swordAttack;
    public int defHealth = 30;
    public int defArmor = 10;
    public int PlayerHealth;
    public int PlayerArmor;
    public HealthBar healthbar;
    public GameOverScreen GameOverScreen;
    public int score = 0;
    public QuitChest QChest;
    public PlayChest PChest;

    Vector2 movementInput;
    SpriteRenderer  spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        PlayerHealth=defHealth;
        PlayerArmor = defArmor;
    }
    private void FixedUpdate()
    {
/*        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerHealth = PlayerHealth + 5;
        }*/
        if (canMove){
            if (movementInput != Vector2.zero){
                bool success = TryMove(movementInput);
                
                if (!success){
                    success = TryMove (new Vector2(movementInput.x, 0));
                
                if (!success){
                    success = TryMove( new Vector2(0, movementInput.y));
                }
                }
                animator.SetBool("isMoving", success);
            }
            else{
                animator.SetBool("isMoving", false);
            }
            if(movementInput.x < 0){
                spriteRenderer.flipX = true;
            }
            else if (movementInput.x > 0){
                spriteRenderer.flipX = false;
            }
        }
    }
    private bool TryMove(Vector2 direction)  {
        if (direction != Vector2.zero){
            int count = rb.Cast(
                direction,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset);

            if (count == 0){            
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else{
                return false;
            }
        }
        else {
            return false;
        }  
    }
    void OnMove(InputValue movementValue){
        movementInput = movementValue.Get<Vector2>();

    }
    void OnFire()  {
        //print ("Fire pressed");
        animator.SetTrigger("swordAttack");
    } 
    void OnAction(){
        QChest.OpenQChest();
        PChest.OpenPChest();
}

    public void SwordAttack(){
        LockMovement();
        if(spriteRenderer.flipX == true){
            swordAttack.AttackLeft();
        }
        else{
            swordAttack.AttackRight();
        }
    }
    
    public void EndSwordAttack(){
        UnlockMovement();
        swordAttack.StopAttack();
    }
    public void LockMovement(){
        canMove = false;
    }

    public void UnlockMovement(){
        canMove = true;
    }
    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "Enemy") {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            TakeDamage(enemy.damage);
            enemy.KnockbackFrom(transform);
            if (PlayerHealth <= 0){
                animator.SetTrigger("death");
                LockMovement(); 
            }
        }
    }
    public void AfterDeath(){
        GameOverScreen.Setup(score);
        Destroy(gameObject);
    }
    
    public void TakeDamage(int damage){
        if (PlayerArmor <= 0){
            PlayerHealth -= damage;
        }
        else{
            PlayerArmor -= damage;
        }
    }

}