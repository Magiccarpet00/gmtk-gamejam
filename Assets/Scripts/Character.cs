using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float currentHP;
    public float maxHP;
    public float damage;
    public float maxSpeed;
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

    public string jesuisbeau;


    void Start()
    {
        currentHP = maxHP;
        moveSpeed = maxSpeed;
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

        if (this.control.Equals("player") &&
            col.tag == "Character" &&
            col.gameObject.GetComponent<Character>().control.Equals("player"))
        {
            moveSpeed = 0f;
            StartCoroutine(GoAndGo());
        }

        if (this.control.Equals("enemy") &&
            col.tag == "Character" &&
            col.gameObject.GetComponent<Character>().control.Equals("enemy"))
        {
            moveSpeed = 0f;
            StartCoroutine(GoAndGo());
        }
    }

    public void targetCharacter(Collider2D col)
    {
        isFighting = true;
        target = col.gameObject;
    }


    // Quand un character est tué on désactuve sa boite de collision
    void OnTriggerExit2D(Collider2D col)
    {
        moveSpeed = maxSpeed;
        isFighting = false;
    }

    void Update()
    {
        if(!isDead){

            if (isFighting)
            {

                if (cd_atkSpeed > atkSpeed)
                {
                    cd_atkSpeed = 0;
                    Fight();
                }
                else
                {
                    cd_atkSpeed++;
                }
            }
            else
            {
                Walk();
            }
        }
    }

    public void DelayAttack()
    {
        if (cd_atkSpeed < atkSpeed)
        {
            cd_atkSpeed++;
        }
    }


    public void Fight()
    {
        if (target.GetComponent<Character>() == null)
        {
            Debug.Log("WARNING BUG");
        }
        else
        {
            bool targetKiled = target.GetComponent<Character>().TakeDamage(this.damage);

            if (targetKiled)
            {
                target = null;
            }
        }
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

    public IEnumerator Delete(){
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }

    public IEnumerator GoAndGo(){
        yield return new WaitForSeconds(2f);
        moveSpeed = maxSpeed;
    }

}
