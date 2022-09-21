using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobChangeColourassesment : MonoBehaviour
{
    private bool isMoving = false;
    public Vector3 objpos;
    public Vector3 mousepos;
    IGB283Transform iGB283Transform = new IGB283Transform();
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

        objpos = transform.GetComponent<Renderer>().bounds.center;
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(isMoving == true)
        {
            Vector3 oldPos = transform.GetComponent<Renderer>().bounds.center;
            Mesh mesh = GetComponent<MeshFilter>().mesh;

            Vector3[] vertices = mesh.vertices;

            IGB283Transform M = iGB283Transform.TranslateX((mousePosition - oldPos).normalized * Time.deltaTime * 50);
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] = M.MultiplyPoint(vertices[i]);
            }

            mesh.vertices = vertices;
            

            mesh.RecalculateBounds();
        }            
        
    }

    //determine if the mouse is over the knob
    void MouseOverAction()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 objectPos = transform.GetComponent<Renderer>().bounds.center;
        
        Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);
        float xdif = Mathf.Abs(Mathf.Abs(objectPos.x) - (Mathf.Abs(mousePosition.x)));
        Debug.Log(xdif);
        float ydif = Mathf.Abs(Mathf.Abs(objectPos.y) - (Mathf.Abs(mousePosition.y)));
        Debug.Log(ydif);
        if (xdif < 2 && ydif < 2)
        {
            Debug.Log("true");
            isMoving = true;
            
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
