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



    public void Awake(){
        instance = this;
    }

    public void initDices()
    {
        //GameObject dice1 = Instantiate(dicePrefab, Vector3.zero, Quaternion.identity);
        //dice1.GetComponent<Dice>().CustomInit("ChaosInvoke1", 5, 1);
        //GameObject dice2 = Instantiate(dicePrefab, Vector3.zero, Quaternion.identity);
        //dice2.GetComponent<Dice>().CustomInit("ChaosInvoke2", 5, 1);
        //GameObject dice3 = Instantiate(dicePrefab, Vector3.zero, Quaternion.identity);
        //dice3.GetComponent<Dice>().CustomInit("ChaosInvoke3", 5, 1);
        //GameObject dice4 = Instantiate(dicePrefab, Vector3.zero, Quaternion.identity);
        //dice4.GetComponent<Dice>().CustomInit("ChaosInvoke4", 5, 1);
        //GameObject dice5 = Instantiate(dicePrefab, Vector3.zero, Quaternion.identity);
        //dice5.GetComponent<Dice>().CustomInit("ChaosInvoke5", 5, 1);
        //GameObject dice6 = Instantiate(dicePrefab, Vector3.zero, Quaternion.identity);
        //dice6.GetComponent<Dice>().CustomInit("ChaosInvoke6", 5, 1);
        //GameObject dice7 = Instantiate(dicePrefab, Vector3.zero, Quaternion.identity);
        //dice7.GetComponent<Dice>().CustomInit("ChaosInvoke7", 5, 1);
        ////GameObject dice8 = Instantiate(dicePrefab, Vector3.zero, Quaternion.identity);
        //dice8.GetComponent<Dice>().CustomInit("ChaosInvoke8", 5, 1);

        //p.pool.Add(dice1.GetComponent<Dice>());
        //p.pool.Add(dice2.GetComponent<Dice>());
        //p.pool.Add(dice3.GetComponent<Dice>());
        //p.pool.Add(dice4.GetComponent<Dice>());
        //p.pool.Add(dice5.GetComponent<Dice>());
        //p.pool.Add(dice6.GetComponent<Dice>());
        //p.pool.Add(dice7.GetComponent<Dice>());
        //p.pool.Add(dice8.GetComponent<Dice>());

        // for test purposes; all dices have equals faces. I'm a lazy boy :-)
        foreach (Dice item in p.pool)
        {
            for (int i = 1; i < Dice.FACES_NUMBER + 1; i++)
            {
                //item.AddFace(i, new FaceEffect(i, "weak melee"));
            }
        }
    }

    void Start()
    {
        p = new DrawManager();
        initDices();

        p.Mulligan();

        // main loop testing : dices should be threw, resolved, put back into the pool, 
        // and our player hand must take a dice from the pool
        for (int i = 0; i < 2; i++)
        {
            p.DebugInfo();
            FaceEffect fe = p.Roll(p.hand[0]);
           
            Resolve(fe,1);
        }
    }
    // all logic to resolve an effect based on description, location of the threw dice, ennemies...

    private void Resolve(FaceEffect fe, int laneNumber)
    {
     //Debug.Log("Spawned " + fe.numberEffect + " " + fe.effect+" on lane "+laneNumber);
    }

    void Update()
    {
        
    }
}
