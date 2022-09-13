using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    IGB283Transform iGB283Transform = new IGB283Transform();
    // Start is called before the first frame update

    public float angle;
    public Vector3 movement = new Vector3(1.0f,0f,0f);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        Vector3[] vertices = mesh.vertices;
        Vector3 currentPos = this.gameObject.transform.position;

        IGB283Transform M = iGB283Transform.Translate(movement);
        IGB283Transform Td1 = iGB283Transform.Translate(-transform.GetComponent<Renderer>().bounds.center);
        IGB283Transform Rs = iGB283Transform.Rotate(angle * Time.deltaTime);
        IGB283Transform Td2 = iGB283Transform.Translate(transform.GetComponent<Renderer>().bounds.center);

         M = M * Td2 * Rs * Td1;

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = M.MultiplyPoint(vertices[i]);
        }

        mesh.vertices = vertices;

        mesh.RecalculateBounds();

       
    }
}
