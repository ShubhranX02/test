using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    private float movX = 1;
    private float movY = 0;
    public float speed = 1;
    
    [SerializeField]
    private GameObject Human;



    // Start is called before the first frame update
    void Start()
    {
       SpawnHuman();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

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
    private void SpawnHuman(){
        bool HumanSpawned = false;
        while(HumanSpawned == false){
            Vector3 HumanPos = new Vector3(Random.Range(-10, 10), Random.Range(-5, 5), 0f); // To spawn human at random position
            if((HumanPos - transform.position).magnitude < 3){
                continue;
            }
            else{
                Instantiate(Human, HumanPos, Quaternion.identity);
                HumanSpawned = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Destroy(collision.gameObject);
        SpawnHuman();
    }
}
