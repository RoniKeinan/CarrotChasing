using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    public FixedJoystick joystick;
    public float moveSpeed;
    int score = 0;
    public TMP_Text scoreText;


    float hInput, vInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        hInput = joystick.Horizontal * moveSpeed;
        vInput = joystick.Vertical * moveSpeed;

        transform.Translate(hInput, vInput, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Carrot")
        {
            score++;
            UpdateScoreText();
            Destroy(collision.gameObject);

        }
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
