using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHand
{
    List<Dice> hand; // Playable dices 
    List<Dice> pool; // Dices that can be drew
    public int MAX_HAND_SIZE = 4;

    PlayerHand()
    {
        hand = new List<Dice>();
        pool = new List<Dice>();
    }

    void Mulligan()
    {
        for (int i = 0; i < MAX_HAND_SIZE; i++)
        {
            hand.Add(Draw(true));
        }
    }

    Dice Draw(bool delFromPool)
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
}

