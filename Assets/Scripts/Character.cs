using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float currentHP;
    public float maxHP;
    public float damage;
    public float moveSpeed;
    
    public bool isDead;
    public bool isFighting;
    public bool isInvoked;
    public bool isStoped;

    public string control; //"player" or "enemy"

    public GameObject target;
    public Collider2D collider2d;
    public GameObject sprite;

    public float atkSpeed; //plus c'est bas, plus c'est rapide
    public float cd_atkSpeed; // une sorte de sablier qui secoule apres chaque coup

    public float atkSpeed_bullet; //plus c'est bas, plus c'est rapide
    public float cd_atkSpeed_bullet;

    void Start()
    {
        currentHP = maxHP;
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
            targetCharacter(col);
        }

        if (this.control.Equals("enemy") && 
            col.tag == "Character" && 
            col.gameObject.GetComponent<Character>().control.Equals("player"))
        {
            targetCharacter(col);
        }
    }

    public void targetCharacter(Collider2D col)
    {
        isFighting = true;
        target = col.gameObject;
    }


    // Quand un character est tu� on d�sactuve sa boite de collision
    void OnTriggerExit2D(Collider2D col)
    {
        isFighting = false;
    }

    void Update()
    {
        if(isFighting){

            if (cd_atkSpeed > atkSpeed) {
                cd_atkSpeed = 0;
                Fight();
            }
            else{
                cd_atkSpeed++;
            }
        }
        else{
            Walk();
        }

        if (cd_atkSpeed_bullet > atkSpeed_bullet)
        {
            cd_atkSpeed_bullet = 0;
            SpawnBullet();
        }
        else
        {
            cd_atkSpeed_bullet++;
        }
    }

    public void DelayAttack()
    {
        if (cd_atkSpeed < atkSpeed)
        {
            cd_atkSpeed++;
        }
    }


    public virtual void Fight()
    {

    }

    public virtual void SpawnBullet(){

    }

    public bool TakeDamage(float damage)
    {
        currentHP -= damage;

        if(currentHP<=0){
            this.Die();
            return true;
        }

        return false;
    }

    public void Die()
    {
        sprite.SetActive(false); //Animation
        collider2d.enabled = false;
    }

}
