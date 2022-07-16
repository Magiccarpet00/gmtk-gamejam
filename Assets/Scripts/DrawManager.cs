using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DrawManager
{
    public List<Dice> hand; // Playable dices 
    public List<Dice> pool; // Dices that can be drew
    public const int MAX_HAND_SIZE = 4;

    public DrawManager()
    {
        hand = new List<Dice>();
        pool = new List<Dice>();
    }

    public void Mulligan()
    {
        for (int i = 0; i < MAX_HAND_SIZE; i++)
        {
            hand.Add(Draw(true));
        }
    }

    public Dice Draw(bool delFromPool)
    {
        // be careful about perma delete from pool. could be handled through parameters
        var random = new System.Random();
        int index = random.Next(pool.Count);
        Dice picked = pool[index];
        if (delFromPool)
        {
            pool.RemoveAt(index);
        }
        Debug.Log("Drew: " + picked.diceName);
        return picked;

    }

    /* 
     * Roll loop :
     * Rolling the dices, and resolving it's effect
     * Drawing a dice and had it to our player hand. 
     * Removing the played dice from our hand, and add it to the pool of dices.
     */
    public FaceEffect Roll(Dice d)
    {
        String infos = "Throwing dice'" + d.diceName + "'\n";
        Debug.Log(infos);
        FaceEffect df = d.RollDice();


        hand.Add(Draw(true));
        pool.Add(d);
        Debug.Log("Adding " + d.diceName + " to my pool");
        hand.Remove(d);
        Debug.Log("Removed " + d.diceName + " from my hand");
        return df;
    }

    public void DebugInfo()
    {
        String infos = "";
        infos += "HAND INFOS\n";
        foreach (Dice item in hand)
        {
            infos += item.diceName + "\n";
        }
        infos+="POOL INFOS\n";
        foreach (Dice item in pool)
        {
            infos+=item.diceName+"\n";
        }
        Debug.Log(infos);
    }
}

