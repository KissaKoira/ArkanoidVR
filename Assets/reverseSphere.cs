using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class reverseSphere : MonoBehaviour
{
    private void reverseMesh()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.triangles = mesh.triangles.Reverse().ToArray();
    }

    void Start()
    {
        reverseMesh();
    }

    void Update()
    {
        
    }
}
