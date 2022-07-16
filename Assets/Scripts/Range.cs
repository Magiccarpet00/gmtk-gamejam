using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : Character
{

    public GameObject bullet;

    public override void Fight()
    {
        base.Fight();

    }

    public override void SpawnBullet(){
        base.SpawnBullet();

        GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
        b.GetComponent<Bullet>().character = this;
    }

}
