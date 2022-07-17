using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject diceInHand;

    public GameObject laneSelected;

    public GameObject[] slotDice;

    public GameObject dicePrefab;

    public GameObject[] gameObjectLanes;

    public float timeLeft;
    public const float MAXIMUM_TIME = 60;
    public const float ENEMY_SPAWN_TICK = 5; // When does enemy appears

    public GameObject[] listEnemysBand;

    public ManaBar manaBar;
    public float mana; // entre 0 et 8

    public int score;
    public TextMeshProUGUI txtScore;

    //DICE ROOL
    public Vector2 offsetEffectDice = new Vector2(0.79f, 0.739f);
    public GameObject diceEffect;

    //Layer
    public int layer;

    //OFFSET SPRITE
    public float offSet_replace;


    public void Awake(){
        instance = this;
    }

    void Start(){
        StartCoroutine(RegenMana());
    }

    public IEnumerator RegenMana()
    {

        yield return new WaitForSeconds(0.01f);

        if (mana < 8){
            mana += 0.005f;
            manaBar.SetMana(mana);
        }

        StartCoroutine(RegenMana());
    }

    public void AddScrore(int _score){
        score += _score;

        string s = score.ToString();
        Debug.Log(s);
        txtScore.SetText(s);
    }

}
