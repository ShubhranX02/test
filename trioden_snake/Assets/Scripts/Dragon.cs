using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dragon : MonoBehaviour
{
    public int score = 0;
    private float movX = 1;
    private float movY = 0;
    public float speed = 3;

    private string HUMAN_TAG = "Human";

    public Text score_display;

    public GameObject Human;

    // Start is called before the first frame update
    void Start()
    {
        SpawnHuman();
    }

    // Update is called once per frame
    void Update()
    {
        speed = 3f + score * 0.01f;
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
        Vector2 HumanPos = new Vector2(); // To spawn human at random position

        HumanPos.x = Random.Range(-8, 8) + 0.5f;
        HumanPos.y = Random.Range(-4, 4) + 0.5f;

        Human.transform.position = HumanPos;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag(HUMAN_TAG))
        {
            SpawnHuman();
            score++;
            score_display.text = "" + score;
        }
    }
}
