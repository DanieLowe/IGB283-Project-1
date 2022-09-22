using UnityEngine;
using System.Collections;
public class Shield : MonoBehaviour
{
    public Material material;
    // Use this for initialization
    void Start()
    {
        // Add a MeshFilter and MeshRenderer to the Empty GameObject
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        // Get the Mesh from the MeshFilter
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        // Set the material to the material we have selected
        GetComponent<MeshRenderer>().material = material;
        // Clear all vertex and index data from the mesh
        mesh.Clear();

    mesh.vertices = new Vector3[] {
        //Triangle 1
        new Vector3(0, 0, 0),//0
        new Vector3(3,3, 0),//1
        new Vector3(-3,3, 0),//2
        //Triangle 2
        new Vector3(-3,-1,0),//3
        //Triangle 3
        new Vector3(0,-3,0),//4
        //Triangle 4
        new Vector3(3,-1,0),//5
        
        
        };
        // Set the colour of the triangle
        mesh.colors = new Color[] {
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
            new Color(0.8f, 0.3f, 0.3f, 1.0f),
         };
        // Set vertex indicies
        mesh.triangles = new int[] { 0,1,2, 0,2,3, 0,3,4, 0,4,5, 0,5,1};
    }
}
