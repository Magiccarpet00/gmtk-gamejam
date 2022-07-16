using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject diceInHand;
    public DrawManager p;

    public GameObject laneSelected;

    public GameObject[] slotDice;

    public GameObject dicePrefab;

    public GameObject[] gameObjectsPool;

    public GameObject[] gameObjectLanes;

    public float timeLeft;
    public float MAXIMUM_TIME = 60;

    public void Awake(){
        instance = this;
    }

    public void initDices()
    {
        for (int i = 0; i < gameObjectsPool.Length; i++)
        {
            p.pool.Add(gameObjectsPool[i].GetComponent<Dice>());
            //faces.Add(i, listFaceEffect[i - 1].GetComponent<FaceEffect>());
        }

    }

    void Start()
    {
        p = new DrawManager();
        initDices();

        p.Mulligan();

        // main loop testing : dices should be threw, resolved, put back into the pool, 
        // and our player hand must take a dice from the pool
        for (int i = 0; i < 3; i++)
        {
            p.DebugInfo();
            FaceEffect fe = p.Roll(p.hand[0]);
            Resolve(fe,1);
        }
    }
    // all logic to resolve an effect based on description, location of the threw dice, ennemies...

    private void Resolve(FaceEffect fe, int laneNumber)
    {
        Debug.Log("Spawned " + fe.numberEffect + " " + fe.character + " on lane "+laneNumber);
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            roundEnd();
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
        
        foreach (GameObject go in gameObjectLanes)
        {
            float distanceMaxPlayer = 0;
            float distanceMaxEnemy = 0;
            Lane l = go.GetComponent<Lane>();
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

            /* Todo calcul au prorata des points selon la distance parcourue */
        }
    }
}
