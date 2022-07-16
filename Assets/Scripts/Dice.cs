using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public string name;
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
            faces.Add(i,listFaceEffect[i].GetComponent<FaceEffect>());
        }
    }

    //public void CustomInit(string name, int variance, int cost)
    //{
    //    this.name = name;
    //    this.variance = variance;
    //    this.cost = cost;
    //    faces = new Dictionary<int, DiceFace>();

    //    //Init empty faces
    //    for (int i = 1; i < FACES_NUMBER + 1; i++)
    //    {
    //        faces.Add(i, new DiceFace());
    //    }
    //}

    // Add an effect on a dice face. 
    public void AddFace(int faceIndex, FaceEffect effect)
    {
        faces[faceIndex] = effect;
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
