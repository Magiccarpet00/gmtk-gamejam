using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice
{
    public string name;
    public int variance;
    public int cost;
    public Dictionary<int,DiceFace> faces;

    public Dice(string name, int variance, int cost)
    {
        this.name = name;
        this.variance = variance;
        this.cost = cost;
        faces = new Dictionary<int, DiceFace>();
    }

    public void AddFace(int faceNumber, string soldierName)
    {
        DiceFace df = new DiceFace(soldierName);
    }
}
