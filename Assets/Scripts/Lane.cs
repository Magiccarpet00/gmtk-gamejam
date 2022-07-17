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

    public void Start()
    {
        StartCoroutine(FirstSpwanEnemy());
        StartCoroutine(SpwanEnemy());

    }

    public IEnumerator SpwanEnemy(){

        float rngTime = Random.Range(10f, 20f);
        yield return new WaitForSeconds(rngTime);

        float rngSpawn = Random.Range(0f, 10f);

        if (rngSpawn > 6f)
        {
            int rngEnemy = Random.Range(0, GameManager.instance.listEnemysBand.Length);
            GameObject enemy = Instantiate(GameManager.instance.listEnemysBand[rngEnemy], spawnEnemy.position, Quaternion.identity);
        }

        StartCoroutine(SpwanEnemy());
    }


    public IEnumerator FirstSpwanEnemy()
    {

        float rngTime = Random.Range(5f, 10f);
        yield return new WaitForSeconds(rngTime);

        float rngSpawn = Random.Range(0f, 10f);

        if(rngSpawn > 5f)
        {
            int rngEnemy = Random.Range(0, GameManager.instance.listEnemysBand.Length);
            GameObject enemy = Instantiate(GameManager.instance.listEnemysBand[rngEnemy], spawnEnemy.position, Quaternion.identity);
        }
    }

}
