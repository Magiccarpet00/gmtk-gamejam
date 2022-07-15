using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public bool onDrag;

    public GameObject sprite;
    public Collider2D collider2d;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        if(!onDrag){
            GameManager.instance.diceInHand = this.gameObject;
            onDrag = true;
            collider2d.enabled = false;
            Debug.Log("j'ai un dé");
        }
        else{
            Disapared();
            Debug.Log("je lache le dé");
        }
    }

    public void Disapared(){
        sprite.SetActive(false);
    }
}
