using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice
{
    public string name;
    public int variance;
    public int cost;
    public const int FACES_NUMBER = 6;
    public Dictionary<int,DiceFace> faces;

    public Dice(string name, int variance, int cost)
    {
        this.name = name;
        this.variance = variance;
        this.cost = cost;
        faces = new Dictionary<int, DiceFace>();
    }

    // Add an effect on a dice face. There can be multiple effects on a face.
    public void AddFace(int faceIndex, FaceEffect effect)
    {
        DiceFace df = new DiceFace();
        faces[faceIndex].effects.Add(effect);
    }

    // When a dice is threw, resolve his effect by randomly choosing a face and check how it turns out
    public DiceFace Roll()
    {
        var random = new System.Random();

        int faceIndex = random.Next(FACES_NUMBER);
        Debug.Log("Rolled an " + faceIndex + " !");
        DiceFace picked = faces[faceIndex];
        return picked;
    }
}
