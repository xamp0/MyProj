using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitScript : MonoBehaviour {
    public QuitChest QC;
    private bool opened = false;
    public void Setup(){
        gameObject.SetActive(true);
        opened = true;
    }
    public void SetDown(){
        gameObject.SetActive(false);       
    }
    public void YesButton(){
        Application.Quit();
    }
    public void NoButton(){
        QC.setdown();
        opened=false;
    }
    private void FixedUpdate(){
        if ((opened == true)&&(Input.GetKeyDown(KeyCode.Escape))){
            QC.setdown();
            opened = false;
        }
    }
}
