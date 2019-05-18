using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float xMin = 1;
    [SerializeField] float xMax = 15;

    GameStatus theGame;
    Ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        theGame = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(getXPos(), xMin, xMax);
        transform.position = paddlePos;
    }

    private float getXPos()
    {
        if (theGame.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
