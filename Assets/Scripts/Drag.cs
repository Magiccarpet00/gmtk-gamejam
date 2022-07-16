using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public bool onDrag;

    public GameObject sprite;
    public Collider2D collider2d;

    public Transform diceSlot;

    public Dice dice;

    void Start(){
        collider2d = gameObject.GetComponent<Collider2D>();
        dice = gameObject.GetComponent<Dice>();
        ReplaceDice();
    }

    void Update()
    {
        if (onDrag)
        {
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            this.transform.SetPositionAndRotation(new Vector3(worldPosition.x, worldPosition.y, 0f), Quaternion.identity);
        }
    }

    void OnMouseUp()
    {
        //TODO Control du coup en mana
        if(!onDrag)
        {
            GameManager.instance.diceInHand = this.gameObject;
            onDrag = true;
        }
        else
        {
            if(GameManager.instance.laneSelected != null &&
               dice.manaCost <= GameManager.instance.mana)
            {
                GameManager.instance.laneSelected.GetComponent<Lane>().DiceRoll(this.gameObject);

                GameManager.instance.mana -= dice.manaCost;
                ReplaceDice();
            }
            else
            {
                //ANNIMATION REFUS DE D�
                ReplaceDice();
            }
        }
    }

    private void ReplaceDice()
    {
        onDrag = false;
        this.transform.position = new Vector3(diceSlot.position.x, diceSlot.position.y, 0f);
    }

}
