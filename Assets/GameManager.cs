using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public Pileczka ball;
    public GameObject loosePanel;
    public Button restartButton;
    bool gamePending = false;

    private void Start()
    {
        loosePanel.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!gamePending)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                gamePending = true;
                ball.StartBall();
            }
        }
    }
    int lives = 3;
    public void Dead()
    {
        lives--;
        if(lives <=0 ) 
        {
            //Game Over
            loosePanel.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
        else
        {
            ball.BallReady();
            gamePending = false;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
