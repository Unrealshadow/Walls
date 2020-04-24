using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangles : MonoBehaviour {

    public GameObject triangleObj;

    private float xOffset;
	// Use this for initialization
	void Start () {
        // Offset for proper placing of the obstacles(triangles)
        // So that they stick out properly from the left and right wall
        if(gameObject.name == "Left")
        {
            xOffset = 0.5f;
        }
        else
        {
            xOffset = -0.5f;
        }
        InitTriangles();
        
	}
	// Creating the obstacles
    private void InitTriangles()
    {
        // Everychild in the transform 
        // Which is all the obstacles in the left or right wall(depending on which wall the player collides with)
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
        // Create 8 obstacles and set there parent as the transform of the tempObj
        // TempObj is currently the triangle obj
        for(int i=0; i<=7; i++)
        {
            int randomY = Random.Range(-6, 7);
            GameObject tempObj = Instantiate(triangleObj, new Vector2(transform.position.x + xOffset, randomY * 1.5f), transform.rotation);
            tempObj.transform.SetParent(transform);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        InitTriangles();
        
    }
}
