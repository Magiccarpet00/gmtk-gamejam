using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public const int FACES_NUMBER = 6;
    public GameObject[] listFaceEffect;

    public float manaCost;

    public AudioClip sound_succes;
    public AudioClip sound_failed;

    public Animator animatorPillier;

    // When a dice is threw, resolve his effect by randomly choosing a face and check how it turns out
    public void RollDice(Lane lane)
    {
        Vector2 offSett = GameManager.instance.offsetEffectDice;
        Instantiate(GameManager.instance.diceEffect, new Vector3(lane.spawnPlayer.transform.position.x + offSett.x, lane.spawnPlayer.transform.position.y + offSett.y), Quaternion.identity);

        animatorPillier.SetTrigger("roll");

        StartCoroutine(RollDiceDelay(lane));

    }

    public IEnumerator RollDiceDelay(Lane lane)
    {
        yield return new WaitForSeconds(2f);

        var random = new System.Random();
        int faceIndex = random.Next(FACES_NUMBER);

        Instantiate(listFaceEffect[faceIndex], lane.spawnPlayer.transform.position, Quaternion.identity);
        faceIndex++;
        Debug.Log("jai fait un " + faceIndex);

        if(faceIndex == 6){
            AudioManager.instance.PlayClipAt(sound_failed, transform.position);
        }
        else
        {
            AudioManager.instance.PlayClipAt(sound_succes, transform.position);
        }
    }


}
