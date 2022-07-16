using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public Transform spawnPlayer;
    public Transform spawnEnemy;

    //Pour les degats
    public List<GameObject> characterOnLane_player;
    public List<GameObject> characterOnLane_enemy;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Dice"){
            //TODO mettre un petit over sur les lanes 

            GameManager.instance.laneSelected = this.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Dice")
        {
            GameManager.instance.laneSelected = null;
        }
    }

    public void DiceRoll(GameObject dice){
        GameManager.instance.laneSelected = null;
        

        dice.GetComponent<Dice>().RollDice(this);
    }

}
