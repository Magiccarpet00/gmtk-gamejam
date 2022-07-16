using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : Character
{

    public GameObject bullet;
    public override void Fight()
    {
        base.Fight();

        //if (target.GetComponent<Character>() == null)
        //{
        //    Debug.Log("WARNING BUG");
        //}
        //else
        //{
        //    bool targetKiled = target.GetComponent<Character>().TakeDamage(this.damage);

        //    if (targetKiled)
        //    {
        //        target = null;
        //    }
        //}

        GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
        b.GetComponent<Bullet>().character = this;
    }

    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range);

        if (hit.collider != null)
        {
            if (this.control.Equals("player") &&
            hit.collider.tag == "Character" &&
            hit.collider.gameObject.GetComponent<Character>().control.Equals("enemy"))
            {
                Debug.Log("toucher");
            }
        }
    }

}
