using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayChest : MonoBehaviour{
    public Transform PChest;
    public Transform playerPos;
    public Playmode PM;
    private bool opened = false;
    Animator animator;
    void Start(){
        animator = GetComponent<Animator>();
    }
    public void OpenPChest(){
        float nearEnough = 0.3f;
        if ((opened != true) && Vector2.Distance(PChest.transform.position, playerPos.transform.position) < nearEnough)
        {
            animator.SetBool("opened", true);
            opened = true;
        }
    }
    public void setup(){
        PM.Setup();
    }
    public void setdown(){
        animator.SetBool("opened",false);
        opened = false;
        PM.SetDown();
    }
}
