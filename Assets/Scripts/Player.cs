using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    public FixedJoystick joystick;
    public float moveSpeed;
    int score = 0;
    public TMP_Text scoreText;
    private bool isBoostActive = false;
    private float originalSpeed;



    float hInput, vInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalSpeed = moveSpeed;
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

        if(collision.gameObject.tag == "SpeedCarrot")
        {
            StartCoroutine(speedBoost());
            Destroy(collision.gameObject);
        }
    }

    IEnumerator speedBoost()
    {
        if (isBoostActive)
            yield break;

        isBoostActive = true;
        moveSpeed *= 2f;

        yield return new WaitForSeconds(10f);
        moveSpeed = originalSpeed;
        isBoostActive = false;
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
