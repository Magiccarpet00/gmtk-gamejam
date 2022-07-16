using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //PROVISOIRE
    public GameObject diceInHand;
    public DrawManager p;

    public GameObject laneSelected;

    public GameObject[] slotDice;

    public GameObject dicePrefab;


    public GameObject[] gameObjectsPool;


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
            //p.DebugInfo();
            FaceEffect fe = p.Roll(p.hand[0]);
            Resolve(fe,1);
        }
    }
    // all logic to resolve an effect based on description, location of the threw dice, ennemies...

    private void Resolve(FaceEffect fe, int laneNumber)
    {
        //Debug.Log("Spawned " + fe.numberEffect + " " + fe.character + " on lane "+laneNumber);
    }

    void Update()
    {
        
    }
}
