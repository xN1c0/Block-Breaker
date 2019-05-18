using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int playerScore;
    [SerializeField] int pointsPerBlockDestroyed;
    [SerializeField] bool isAutoPlayEnabled;
    TextMeshProUGUI pointsText;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1)
        {
            Debug.Log("DESTROY");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("DO NOT DESTROY");
            DontDestroyOnLoad(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        pointsPerBlockDestroyed = 53;
        playerScore = 0;
        pointsText = FindObjectOfType<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;       
       
    }

    public void addPoints()
    {
        playerScore += pointsPerBlockDestroyed;
        pointsText.SetText(playerScore.ToString());
    }

    public void resetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
