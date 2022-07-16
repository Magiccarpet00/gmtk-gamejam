using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //PROVISOIRE
    public GameObject diceInHand;
    public PlayerHand p;

    public void Awake(){
        instance = this;
    }

    public void initDices()
    {
        Dice d1 = new Dice("ChaosInvoke1", 5, 1);
        Dice d2 = new Dice("ChaosInvoke2", 5, 1);
        Dice d3 = new Dice("ChaosInvoke3", 5, 1);
        Dice d4 = new Dice("ChaosInvoke4", 5, 1);
        Dice d5 = new Dice("ChaosInvoke5", 5, 1);
        Dice d6 = new Dice("ChaosInvoke6", 5, 1);
        Dice d7 = new Dice("ChaosInvoke7", 5, 1);
        Dice d8 = new Dice("ChaosInvoke8", 5, 1);

        p.pool.Add(d1);
        p.pool.Add(d2);
        p.pool.Add(d3);
        p.pool.Add(d4);
        p.pool.Add(d5);
        p.pool.Add(d6);
        p.pool.Add(d7);
        p.pool.Add(d8);

        // for test purposes; all dices have equals faces. I'm a lazy boy :-)
        foreach (Dice item in p.pool)
        {
            for (int i = 0; i < 5; i++)
            {
                item.AddFace(i, new FaceEffect(i, "weak melee"));
            }
        }
    }

    void Start()
    {
        p = new PlayerHand();
        initDices();

        p.Mulligan();
        //p.DebugInfo();

        DiceFace df = p.pool[0].Roll();
        String infos = "Throwing dice'"+ p.pool[0].name+"'\n";
        Debug.Log("infos");
        foreach  (FaceEffect fe in df.effects)
        {
            Resolve(fe,1);
        }


    }
    // all logic to resolve an effect based on description, location of the threw dice, ennemies...

    private void Resolve(FaceEffect fe, int laneNumber)
    {
        Debug.Log("Spawned " + fe.numberEffect + " " + fe.effect+" on lane "+laneNumber);
    }

    void Update()
    {
        
    }
}
