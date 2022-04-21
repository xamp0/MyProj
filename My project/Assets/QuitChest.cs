using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitChest : MonoBehaviour{
    public Transform QChest;
    public Transform playerPos;
    public QuitScript QS;
    private bool opened = false;
    Animator animator;
    void Start(){
        animator = GetComponent<Animator>();
    }
    public void OpenQChest(){
        float nearEnough = 0.3f;
        if ((opened != true)&&Vector2.Distance(QChest.transform.position, playerPos.transform.position) < nearEnough) {
            animator.SetBool("opened",true);
            opened = true;
        }
    }
    public void setup(){
        QS.Setup();
    }
    public void setdown(){
        animator.SetBool("opened",false);
        opened = false;
        QS.SetDown();
    }
    
}
