using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public string diceName;
    public int variance;
    public int cost;
    public const int FACES_NUMBER = 6;
    public GameObject[] listFaceEffect;
    public Dictionary<int,FaceEffect> faces;
    
    public void Start()
    {
        faces = new Dictionary<int, FaceEffect>();

        //Init empty faces
        for (int i = 1; i < FACES_NUMBER + 1; i++)
        {
            faces.Add(i,listFaceEffect[i-1].GetComponent<FaceEffect>());
        }
    }


    // When a dice is threw, resolve his effect by randomly choosing a face and check how it turns out
    public FaceEffect RollDice()
    {
        var random = new System.Random();

        int faceIndex = random.Next(FACES_NUMBER) + 1;
        Debug.Log("Rolled an " + faceIndex + " !");
        FaceEffect picked = faces[faceIndex];
        return picked;
    }
}
