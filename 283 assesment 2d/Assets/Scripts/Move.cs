using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    IGB283Transform iGB283Transform = new IGB283Transform();
    
    private Vector3 Pos;

    public GameObject target1;
    public GameObject target2;

    public GameObject speedSlider;
    public GameObject spinSlider;    

    protected bool targetChange = true;
    protected bool centre = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        //check position and target of object
        if (transform.GetComponent<Renderer>().bounds.center.x >= 238 && targetChange == true)
        {
            targetChange = false;
        }

        if (transform.GetComponent<Renderer>().bounds.center.x <= 82 && targetChange == false)
        {
            targetChange = true;
        }
        //change target if conditions are met
        if (targetChange == true)
        {
            MoveToTarget(target2);
        }

        if(targetChange == false)
        {
            MoveToTarget(target1);
        }

        if (transform.GetComponent<Renderer>().bounds.center.x > 160)
        {
            ColourChange(new Color(1.0f, 0.6f, 0.8f, 1.0f));            
            
        }

        else
        {
            ColourChange(new Color(0.2f, 0.6f, 0.8f, 0.4f));
        }

       
    }

    /// <summary>
    /// function that translates and rotates an object towards a specified gameObject
    /// </summary>
    /// <param name="target"> target gameObject to move towards </param>
    void MoveToTarget (GameObject target)
    {
        //get last position of game object
        Pos = transform.GetComponent<Renderer>().bounds.center;
        
        //get mesh and vertices
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        
        //calculate unit vector to translate by
        Vector3 moveto = (target.GetComponent<Renderer>().bounds.center - Pos).normalized;

        if (transform.GetComponent<Renderer>().bounds.center.x > 160 && centre == true)
        {
            IGB283Transform M = iGB283Transform.Translate(moveto * Time.deltaTime * speedSlider.GetComponent<Slider>().value);
            IGB283Transform S = iGB283Transform.Scale(2f);
            //translate and rotate object
            IGB283Transform Td1 = iGB283Transform.Translate(-Pos);
            IGB283Transform Rs = iGB283Transform.Rotate(spinSlider.GetComponent<Slider>().value * Time.deltaTime);
            IGB283Transform Td2 = iGB283Transform.Translate(Pos);

            M = Td2 * M * Rs * S * Td1 ;

            //re-define the vertices of the object after translations. 
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] = M.MultiplyPoint(vertices[i]);
            }

            mesh.vertices = vertices;

            mesh.RecalculateBounds();
            centre = false;
        }
        if (transform.GetComponent<Renderer>().bounds.center.x < 160 && centre == false)
        {
            IGB283Transform M = iGB283Transform.Translate(moveto * Time.deltaTime * speedSlider.GetComponent<Slider>().value);
            IGB283Transform S = iGB283Transform.Scale(0.5f);
            //translate and rotate object
            IGB283Transform Td1 = iGB283Transform.Translate(-Pos);
            IGB283Transform Rs = iGB283Transform.Rotate(spinSlider.GetComponent<Slider>().value * Time.deltaTime);
            IGB283Transform Td2 = iGB283Transform.Translate(Pos);

            M = Td2 * M * Rs * S * Td1;

            //re-define the vertices of the object after translations. 
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] = M.MultiplyPoint(vertices[i]);
            }

            mesh.vertices = vertices;

            mesh.RecalculateBounds();
            centre = true;
        }
        else
        {
            IGB283Transform M = iGB283Transform.Translate(moveto * Time.deltaTime * speedSlider.GetComponent<Slider>().value);

            //translate and rotate object
            IGB283Transform Td1 = iGB283Transform.Translate(-Pos);
            IGB283Transform Rs = iGB283Transform.Rotate(spinSlider.GetComponent<Slider>().value * Time.deltaTime);
            IGB283Transform Td2 = iGB283Transform.Translate(Pos);

            M = Td2 * M * Rs * Td1;

            //re-define the vertices of the object after translations. 
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] = M.MultiplyPoint(vertices[i]);
            }

            mesh.vertices = vertices;

            mesh.RecalculateBounds();
        }
        //translate object
        
    }

    void ColourChange(Color newcolor)
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
