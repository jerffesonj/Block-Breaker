using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int scorePerBlockDestroyed = 10;
    [SerializeField] bool autoplay = false;
    [SerializeField] int currentScore = 0;

    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject paddle;
    [SerializeField] int spawnnedBalls;
    [SerializeField] Ball ballScript;

    // Start is called before the first frame update


    void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        scoreText.text = currentScore.ToString();
    }

    public void AddToScore()
    {
        currentScore += scorePerBlockDestroyed;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    } 

    public bool IsAutoPlayerEnable()
    {
        return autoplay;
    }

    void SpawnMoreBalls()
    {
        //if (ballScript.HasStarted())
        {
            for (int i = 0; i <= spawnnedBalls; i++)
            {
                Instantiate(ball, paddle.transform.position, paddle.transform.rotation);
            }
        }
    }
}

