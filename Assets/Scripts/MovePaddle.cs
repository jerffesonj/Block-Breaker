using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour
{
    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float minValue = 1f;
    [SerializeField] float maxValue = 15f;

    GameStatus gameStatus;
    Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2 (this.transform.position.x, this.transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minValue, maxValue);
        transform.position = paddlePos;


    }

    private float GetXPos()
    {
        if (gameStatus.IsAutoPlayerEnable())
        {
            return ball.transform.position.x;
        }
        else
        {
            return (Input.mousePosition.x / Screen.width * screenWidthUnits);
        }
    }
}
