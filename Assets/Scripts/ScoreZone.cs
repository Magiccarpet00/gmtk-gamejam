using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    public string zone;

    public AudioClip[] playerWinSound;
    public AudioClip[] enemyWinSound;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (zone.Equals("enemy") &&
            col.tag == "Character" &&
            col.gameObject.GetComponent<Character>().control.Equals("enemy"))
        {
            GameManager.instance.AddScrore(-10);

            int rng = Random.Range(0, 3);
            AudioManager.instance.PlayClipAt(enemyWinSound[rng], transform.position);
        }

        if (zone.Equals("player") &&
            col.tag == "Character" &&
            col.gameObject.GetComponent<Character>().control.Equals("player"))
        {
            GameManager.instance.AddScrore(10);
            int rng = Random.Range(0, 3);
            AudioManager.instance.PlayClipAt(playerWinSound[rng], transform.position);
        }
    }

}
