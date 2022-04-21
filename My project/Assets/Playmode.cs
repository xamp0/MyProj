using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playmode : MonoBehaviour{
    public PlayChest PC;
    private bool opened = false;
    public void Setup(){
        gameObject.SetActive(true);
        opened = true;
    }
    public void SetDown(){
        gameObject.SetActive(false);
    }
    public void Practice(){
        SceneManager.LoadScene("Practice", LoadSceneMode.Single);
    }
    public void Rlike(){
        SceneManager.LoadScene("1stROOM", LoadSceneMode.Single);   
    }
    private void FixedUpdate(){
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PC.setdown();
            opened = false;
        }
    }
}
