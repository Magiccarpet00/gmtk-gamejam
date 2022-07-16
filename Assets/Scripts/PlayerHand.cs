using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHand
{
    public List<Dice> hand; // Playable dices 
    public List<Dice> pool; // Dices that can be drew
    public int MAX_HAND_SIZE = 4;

    public PlayerHand()
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
        return picked;
    }

    public void DebugInfo()
    {
        String infos = "";
        infos += "HAND INFOS\n";
        foreach (Dice item in hand)
        {
            infos += item.name + "\n";
        }
        infos+="POOL INFOS\n";
        foreach (Dice item in pool)
        {
            infos+=item.name+"\n";
        }
        Debug.Log(infos);
    }
}

