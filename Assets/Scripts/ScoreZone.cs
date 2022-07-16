using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    public string zone;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (zone.Equals("enemy") &&
            col.tag == "Character" &&
            col.gameObject.GetComponent<Character>().control.Equals("enemy"))
        {
            GameManager.instance.AddScrore(-10);
        }

        if (zone.Equals("player") &&
            col.tag == "Character" &&
            col.gameObject.GetComponent<Character>().control.Equals("player"))
        {
            GameManager.instance.AddScrore(10);
        }
    }

}
