using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShieldColourMove : MonoBehaviour
{
    private bool isMoving = false;
    protected Vector3 objpos;
    protected Vector3 mousepos;
    IGB283Transform iGB283Transform = new IGB283Transform();
    
    public AudioSource[] audioSource = new AudioSource[2];
    public AudioClip[] audioClip = new AudioClip[2];
    // Start is called before the first frame update
    void Start()
    {
        audioClip[0] = Resources.Load<AudioClip>("ShieldSound");

        audioSource[0] = this.GetComponent<AudioSource>();

        audioSource[0].clip = audioClip[0];
    }

    // Update is called once per frame
    void Update()
    {
        MouseClickAction();
        Move();
        

        objpos = transform.GetComponent<Renderer>().bounds.center;
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Change the colour of the object
    

    void Move()
    {
        //find the mouse position in the world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(isMoving == true)
        {
            Vector3 oldPos = transform.GetComponent<Renderer>().bounds.center;
            Mesh mesh = GetComponent<MeshFilter>().mesh;

            Vector3[] vertices = mesh.vertices;

            IGB283Transform M = iGB283Transform.TranslateX((mousePosition - oldPos).normalized * Time.deltaTime * 200);
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
            float f1 = Random.Range(0f, 1f);
            float f2 = Random.Range(0f, 1f);
            float f3 = Random.Range(0f, 1f);
            float f4 = Random.Range(0f, 1f);

            ColourChange(new Color(f1, f2, f3, 1.0f));
            audioSource[0].Play();

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

    void ColourChange (Color newcolor)
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Color[] colors = mesh.colors;
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = newcolor; 
        }
        mesh.colors = colors;
        
    }

    
}
