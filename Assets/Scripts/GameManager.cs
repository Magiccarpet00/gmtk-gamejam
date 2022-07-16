using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject diceInHand;

    public GameObject laneSelected;

    public GameObject[] slotDice;

    public GameObject dicePrefab;

    public GameObject[] gameObjectLanes;

    public float timeLeft;
    public const float MAXIMUM_TIME = 60;
    public const float ENEMY_SPAWN_TICK = 5; // When does enemy appears

    public GameObject[] listEnemysBand;

    public ManaBar manaBar;
    public float mana; // entre 0 et 8

    public void Awake(){
        instance = this;
    }

    void Start()
    {
        //p = new DrawManager();
        //initDices();

        //p.Mulligan();
        //countScoreLane(gameObjectLanes[0]);
        // main loop testing : dices should be threw, resolved, put back into the pool, 
        // and our player hand must take a dice from the pool

        //for (int i = 0; i < 3; i++)
        //{
        //    p.DebugInfo();
        //    FaceEffect fe = p.Roll(p.hand[0]);
        //    Resolve(fe,1);
        //}
        
    }
    // all logic to resolve an effect based on description, location of the threw dice, ennemies...

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            roundEnd();
        }

        RegenMana();
    }

    void RegenMana()
    {
        if(mana < 8){
            mana += 0.001f;
            manaBar.SetMana(mana);
        }
    }

    private void roundStart()
    {
        throw new NotImplementedException();
    }
    private void roundEnd()
    {
        countScore();
    }

    /*
     * When game end, we check for each lane how far the soldiers went.
     * Kinda sucks if a soldier die just before reaching the end but that's what it take
     * to be a dummy soldier
     * */
    private void countScore()
    {
       // Debug.Log("1 partout balle au centre");
    }
    private void countScoreLane(GameObject lane)
    {
        float distanceMaxPlayer = 0;
        float distanceMaxEnemy = 0;
        float distanceSpawns = Vector3.Distance(
            lane.GetComponent<Lane>().spawnEnemy.transform.position, 
            lane.GetComponent<Lane>().spawnPlayer.transform.position
        );
        
        Lane l = lane.GetComponent<Lane>();
        foreach (GameObject playerCharGo in l.characterOnLane_player)
        {
            float distTmp = Vector3.Distance(l.spawnPlayer.position, playerCharGo.transform.position);
            if (distTmp > distanceMaxPlayer)
            {
                distanceMaxPlayer = distTmp;
            }
        }
        foreach (GameObject enemyCharGo in l.characterOnLane_enemy)
        {
            float distTmp = Vector3.Distance(l.spawnEnemy.position, enemyCharGo.transform.position);
            if (distTmp > distanceMaxEnemy)
            {
                distanceMaxEnemy = distTmp;
            }
        }

        float progPlayer = ( distanceMaxPlayer / distanceSpawns )*100;
        float progEnemy = (distanceMaxEnemy / distanceSpawns) * 100;
        /* TODO :
         * What happens if a lane is fully conquered
         * How does scoring exactly work (I guess we just sum each progression on each lanes and compare the totals)
         */
        
    }
}
