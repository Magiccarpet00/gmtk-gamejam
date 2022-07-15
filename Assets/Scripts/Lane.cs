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

    void OnMouseUp()
    {
        if(GameManager.instance.diceInHand != null){
            Debug.Log(GameManager.instance.diceInHand);
        }
        else{
            Debug.Log("pas de dé en main");
        }
    }


}
