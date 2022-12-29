using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)); // To calculate screen boundary
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        Vector3 viewPosInitial = transform.position; // gets the initial position
        
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * - 1 + objectWidth, screenBounds.x - objectWidth );
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * - 1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;

        if (viewPosInitial != viewPos) // checks for collision
        {
            Debug.Log("collision");
        }
    }   
}
