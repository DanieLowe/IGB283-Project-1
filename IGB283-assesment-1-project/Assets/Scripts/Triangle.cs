using System.Collections;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    public Material material;
   
    void Start()
    {
        // Add a MeshFilter and MeshRenderer to the TriangleMesh (GameObject)

        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        // Get the Mesh from MeshFilter
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        // Set the material to material 
        GetComponent<MeshRenderer>().material = material;
        // Clear all vertex and index data from the mesh
        mesh.Clear();
        // Create a triangle with the Points
       

        mesh.vertices = new Vector3[] {
            //Triangle 1
            new Vector3(0,9,0), //0 
            new Vector3(-1,7,0),//1
            new Vector3(1,7,0),//2
            //Triangle 2
            
            new Vector3(1,-2,0),//3
            //Triangle 3
            
            new Vector3(-1,-2,0),//4
            
            //Triangle 4
            new Vector3(-3,-2,0),//6
            new Vector3(3,-2,0),//7
            new Vector3(3,-3,0),//8
            //Triangle 5
            
            new Vector3(-3,-3,0),//9
            
            //Triangle 6
           
            new Vector3(-4,-3,0),//10
            
            //Triangle 7
            
            new Vector3(4,-3,0),//11
            
            //Triangle 8
            new Vector3(-2,-3,0),//12
            new Vector3(-1,-3,0),//13
            new Vector3(-1,-4,0),//14
            //Triangle 9
            new Vector3(2,-3,0),//15
            new Vector3(1,-3,0),//16
            new Vector3(1,-4,0),//17
            //Triangle 10
            
            new Vector3(1,-9,0),//18
            //Triangle 13
           
            new Vector3(-1,-9,0),//19
            
            
        };
        // Setting color of triangles
        mesh.colors = new Color[] {
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
            



        };
        // Set vertex indicies
        mesh.triangles = new int[] { 0, 1, 2, 2, 1, 4, 2, 4, 3 , 5, 6, 7, 5, 8, 7, 5, 9, 8, 6, 10, 7, 11, 12, 13, 14, 15, 16, 
            15, 16, 12, 12, 13, 16, 13, 16, 17, 13, 18, 17 };
    }
}


