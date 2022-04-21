using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomAdd : MonoBehaviour
{
    private RoomTemplates templates;
    void Start(){
    templates = GameObject.FindWithTag("RoomTemplate").GetComponent<RoomTemplates>();
    templates.rooms.Add(this.gameObject);
    }
}
