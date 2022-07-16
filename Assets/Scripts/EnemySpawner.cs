using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class contains a list made of ennemies that we can summon.
 * The 'characters' list should be filled with prefab of characters
 * The 'possibleGroup' will be a list of groups of characters that we decided.
 * The goal is to periodically summon in GameManager a random group declared in 'possibleGroup'
 * and spread them along the lanes */
public class EnemySpawner {
    // Start is called before the first frame update
    public List<GameObject> characters;
    public List<List<GameObject>> possibleGroups;

    public void Init()
    {
        possibleGroups = new List<List<GameObject>>();
        List<GameObject> group1 = new List<GameObject>();
        group1.Add(characters[0]);
        group1.Add(characters[1]);
        group1.Add(characters[2]);
        List<GameObject> group2 = new List<GameObject>();
        group2.Add(characters[0]);
        group2.Add(characters[1]);
        List<GameObject> group3 = new List<GameObject>();
        group3.Add(characters[1]);
        group3.Add(characters[2]);
        List<GameObject> group4 = new List<GameObject>();
        group4.Add(characters[1]);
        group4.Add(characters[1]);
        group4.Add(characters[1]);
        List<GameObject> group5 = new List<GameObject>();
        group5.Add(characters[2]);

        possibleGroups.Add(group1);
        possibleGroups.Add(group2);
        possibleGroups.Add(group3);
        possibleGroups.Add(group4);
        possibleGroups.Add(group5);

    }
}
