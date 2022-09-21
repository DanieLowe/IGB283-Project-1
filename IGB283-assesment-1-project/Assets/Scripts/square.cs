using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class square : MonoBehaviour
{
    public Material material;
    public GameObject selectedObject;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //add a meshfilter and mesh renderer
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        //get the mesh from the mesh filter
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        //set the material 
        GetComponent<MeshRenderer>().material = material;

        //clear all vertex and index data from mesh.
        mesh.Clear();

        //create triangles
        mesh.vertices = new Vector3[]
        {
            new Vector3(-2,-2,1),
            new Vector3(-2,2,1),
            new Vector3(2,2,1),
            new Vector3(2,-2,1)
        };

        //set colors
        mesh.colors = new Color[]
        {
            new Color(0.8f,0.3f,0.3f,1.0f),
            new Color(0.8f,0.3f,0.3f,1.0f),
            new Color(0.8f,0.3f,0.3f,1.0f),
            new Color(0.8f,0.3f,0.3f,1.0f)
        };

        //set vertex indicies
        mesh.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                selectedObject = targetObject.transform.gameObject;
                offset = selectedObject.transform.position - mousePosition;
            }
        }
        if (selectedObject)
        {
            selectedObject.transform.position = mousePosition + offset;
        }
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject = null;
        }
    }
}
    

