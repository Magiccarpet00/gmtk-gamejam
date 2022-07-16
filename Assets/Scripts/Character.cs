using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float currentHP;
    public float maxHP;
    public float damage;
    public float moveSpeed;
    public float range;
    public bool isDead;
    public bool isFighting;
    public bool isInvoked;
    public bool isStoped;

    public string control; //"player" or "enemy"

    void Start()
    {
        
    }

    public void Walk()
    {
        if(control.Equals("player")){
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        else if(control.Equals("enemy"))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (this.control.Equals("player") &&
            col.tag == "Character" &&
            col.gameObject.GetComponent<Character>().control.Equals("enemy"))


        {
            isFighting = true;
        }

        if (this.control.Equals("player") && 
            col.tag == "Character" && 
            col.gameObject.GetComponent<Character>().control.Equals("player"))
        {
            isFighting = true;
        }
    }

    // Quand un character est tué on désactuve sa boite de collision
    void OnTriggerExit2D(Collider2D col){
        isFighting = false;
    }

    void Update()
    {
        if(isFighting){
            Fight();
        }
        else{
            Walk();
        }
    }

    void Fight()
    {

    }

}
