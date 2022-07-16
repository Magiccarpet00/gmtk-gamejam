using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public const int FACES_NUMBER = 6;
    public GameObject[] listFaceEffect;

    // When a dice is threw, resolve his effect by randomly choosing a face and check how it turns out
    public void RollDice(Lane lane)
    {
        var random = new System.Random();

        int faceIndex = random.Next(FACES_NUMBER);

        Debug.Log("jai fait un " + faceIndex+1);

        Instantiate(listFaceEffect[faceIndex], lane.spawnPlayer.transform.position, Quaternion.identity);
        
    }


}
