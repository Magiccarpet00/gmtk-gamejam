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


    public Animator animatorDice;

    void Start(){
        collider2d = gameObject.GetComponent<Collider2D>();
        dice = gameObject.GetComponent<Dice>();
        StartCoroutine(ReplaceDice(0f));
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
                StartCoroutine(ReplaceDice(1.5f));
            }
            else
            {
                animatorDice.SetTrigger("nomana");
                Debug.Log("hello");
                StartCoroutine(ReplaceDice(0f));
            }
        }
    }

    private IEnumerator ReplaceDice(float time)
    {
        
        sprite.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        
        onDrag = false;
        this.transform.position = new Vector3(diceSlot.position.x, diceSlot.position.y + GameManager.instance.offSet_replace , 0f);
        yield return new WaitForSeconds(time);

        sprite.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

    }

}
