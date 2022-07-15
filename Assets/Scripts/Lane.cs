using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("hello");
    }

    void OnMouseUp()
    {
        if(GameManager.instance.diceInHand != null){
            Debug.Log(GameManager.instance.diceInHand);
            GameManager.instance.diceInHand.GetComponent<Drag>().Disapared();
            Debug.Log("dé lacher");

        }
        else{
            Debug.Log("pas de dé en main");
        }
    }


}
