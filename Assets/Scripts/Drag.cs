using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public bool onDrag;

    public Transform t;

    void OnMouseUp()
    {
        GameManager.instance.diceInHand = this.gameObject;
        onDrag = true;
        Debug.Log("j'ai un dé");
    }

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
            Debug.Log(worldPosition.x);
            Debug.Log(worldPosition.y);

            this.transform.SetPositionAndRotation(new Vector3(worldPosition.x, worldPosition.y, 0f), Quaternion.identity);
        }


    }
}
