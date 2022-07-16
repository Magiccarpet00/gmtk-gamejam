using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice
{
    public string name;
    public int variance;
    public Dictionary<int,DiceFace> faces;

    Dice(string name, int variance)
    {
        this.name = name;
        this.variance = variance;
        faces = new Dictionary<int, DiceFace>();
    }

    public void AddFace(int faceNumber, string soldierName)
    {
        DiceFace df = new DiceFace(soldierName);
        
    }
}
