using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //PROVISOIRE
    public GameObject diceInHand;

    public GameObject laneSelected;



    public void Awake(){
        instance = this;
    }

    void Start()
    {
        Dice d1 = new Dice("ChaosInvoke1", 5, 1);
        Dice d2 = new Dice("ChaosInvoke2", 5, 1);
        Dice d3 = new Dice("ChaosInvoke3", 5, 1);
        Dice d4 = new Dice("ChaosInvoke4", 5, 1);
        Dice d5 = new Dice("ChaosInvoke5", 5, 1);
        Dice d6 = new Dice("ChaosInvoke6", 5, 1);
        Dice d7 = new Dice("ChaosInvoke7", 5, 1);
        Dice d8 = new Dice("ChaosInvoke8", 5, 1);
        PlayerHand p = new PlayerHand();
        p.pool.Add(d1);
        p.pool.Add(d2);
        p.pool.Add(d3);
        p.pool.Add(d4);
        p.pool.Add(d5);
        p.pool.Add(d6);
        p.pool.Add(d7);
        p.pool.Add(d8);

        p.Mulligan();
        p.DebugInfo();

    }

    
    void Update()
    {
        
    }
}
