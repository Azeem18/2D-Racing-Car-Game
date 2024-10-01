using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Movement : MonoBehaviour
{

    public Renderer meshRenderer;
    public float speed = 0.5f ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*Here we get offset component of meshRenderer to make our road moveable
        Vector2 type is used for variabes to store x,y values
        Similarly Vector3 is type is used for x,y,z values
        */

        // Vector2 offset = meshRenderer.material.mainTextureOffset;
        // offset = offset + new Vector2(0,speed*Time.deltaTime);
        // meshRenderer.material.mainTextureOffset = offset;
        // Instead of these three line code, we can use single line code to move our road
          
        meshRenderer.material.mainTextureOffset += new Vector2(0,speed*Time.deltaTime);

    }
}
