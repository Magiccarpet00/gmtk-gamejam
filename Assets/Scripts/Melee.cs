using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Character
{

    public override void Fight(){
        base.Fight();

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
    public override void SpawnBullet(){
        base.SpawnBullet();
    }

}
