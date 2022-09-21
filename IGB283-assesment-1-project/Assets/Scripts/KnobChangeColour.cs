using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobChangeColour : MonoBehaviour
{
    public bool isMoving = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MouseClickAction();
        Move();
        ChangeKnobColour();
    }

    // Change the colour of the object
    void ChangeKnobColour()
    {
        if (Input.GetKeyDown("q"))
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (Input.GetKeyDown("w"))
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    void Move()
    {
        //find the mouse position in the world space
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(isMoving == true)
        {
            transform.position = mousePosition;
        }            
        
    }

    //determine if the mouse is over the knob
    void MouseOverAction()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

        if (hitCollider && hitCollider.transform.tag == "Knob")
        {
            Debug.Log("true");
            hitCollider.transform.gameObject.GetComponent<KnobChangeColour>().isMoving = true;
            
        }
    }

    void MouseClickAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse call");
            MouseOverAction();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
            Debug.Log("false");
        }
    }
}
