using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    private float movX = 1;
    private float movY = 0;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h > 0) // Right
        {
            movX = speed;
            movY = 0;
        }
        else if (h < 0) // Left
        {
            movX = -speed;
            movY = 0;
        }
        else if (v > 0) // Up
        {
            movX = 0;
            movY = speed;
        }
        else if (v < 0) // Down
        {
            movX = 0;
            movY = -speed;
        }
        
        Vector2 pos = transform.position;

        pos.x += Time.deltaTime * movX;
        pos.y += Time.deltaTime * movY;

        transform.position = pos;
    }
}
