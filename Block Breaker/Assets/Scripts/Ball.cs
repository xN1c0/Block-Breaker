using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 8f;
    Vector2 paddleToBallVector;
    Boolean isLocked = true;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = this.transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isLocked)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        
    }

    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isLocked = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        this.transform.position = paddlePosition + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isLocked)
            GetComponent<AudioSource>().Play();
    }
}
