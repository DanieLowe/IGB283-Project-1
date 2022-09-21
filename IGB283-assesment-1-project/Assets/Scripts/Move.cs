using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    IGB283Transform iGB283Transform = new IGB283Transform();
    
    public float angle;
    
    private Vector3 oldPos;
    public Vector3 startPos;

   
    public GameObject target1;
    public GameObject target2;

    public float speed;

    protected bool targetChange = true;

    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = this.gameObject.GetComponent<MeshFilter>().mesh;

        Vector3[] vertices = mesh.vertices;

        IGB283Transform T = iGB283Transform.Translate(startPos);

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = T.MultiplyPoint(vertices[i]);
        }

        mesh.vertices = vertices;

        mesh.RecalculateBounds();
        Debug.Log(startPos);
        
    }

    // Update is called once per frame
    void Update()
    {  
        
        if (transform.GetComponent<Renderer>().bounds.center.x >= 78 && targetChange == true)
        {
            targetChange = false;
        }

        if (transform.GetComponent<Renderer>().bounds.center.x <= -78 && targetChange == false)
        {
            targetChange = true;
        }

        if (targetChange == true)
        {
            MoveToTarget(target2);
        }

        if(targetChange == false)
        {
            MoveToTarget(target1);
        }
        

    }

    void MoveToTarget (GameObject target)
    {
        oldPos = transform.GetComponent<Renderer>().bounds.center;
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        Vector3[] vertices = mesh.vertices;
        
        Vector3 moveto = (target.transform.position - oldPos).normalized;

        IGB283Transform M = iGB283Transform.Translate(moveto * Time.deltaTime * speed);

        IGB283Transform Td1 = iGB283Transform.Translate(-oldPos);
        IGB283Transform Rs = iGB283Transform.Rotate(angle * Time.deltaTime);
        IGB283Transform Td2 = iGB283Transform.Translate(oldPos);

        M = Td2 * M * Rs * Td1;

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = M.MultiplyPoint(vertices[i]);
        }

        mesh.vertices = vertices;

        mesh.RecalculateBounds();
    }
}
