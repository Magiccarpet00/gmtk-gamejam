using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Range character;

    public Vector3 dir;

    void Start()
    {
        if(character.control.Equals("player")){
            dir = Vector3.right;
        }
        else if(character.control.Equals("enemy")){
            dir = Vector3.left;
        }
    }

    void Update()
    {
        Move();
    }

    void Move(){
        transform.position += dir * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (character.control.Equals("player") &&
            col.tag == "Character" &&
            col.gameObject.GetComponent<Character>().control.Equals("enemy"))
        {
            bulletHit(col);
        }

        if (character.control.Equals("enemy") &&
            col.tag == "Character" &&
            col.gameObject.GetComponent<Character>().control.Equals("player"))
        {
            bulletHit(col);
        }
    }

    void bulletHit(Collider2D col)
    {
        col.gameObject.GetComponent<Character>().TakeDamage(character.damage);
        DeleteBullet();
    }

    void DeleteBullet(){
        Destroy(this.gameObject); //TODO ANNIMATION
    }

}
