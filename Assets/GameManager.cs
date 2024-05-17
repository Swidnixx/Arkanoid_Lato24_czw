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

    int lives = 3;
    public Pileczka ball;
    public GameObject loosePanel;
    public GameObject winPanel;
    public Button restartButton;

    public Text textZycie;
    public Text klockiText;
    public Text levelText;

    bool gamePending = false;

    public Generator generator;
    int level = 1;

    private void Start()
    {
        loosePanel.SetActive(false);
        winPanel.SetActive(false);
        restartButton.gameObject.SetActive(false);

        generator.Generate(level-1);

        UpdateUI();
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
        else
        {
            if(generator.Klocki == 0)
            {
                gamePending = false;
                level++;
                if(level < generator.Levels) 
                {
                    ball.StopBall();
                    ball.BallReady();
                    generator.Generate(level-1);
                    UpdateUI();
                }
                else
                {
                    //wygrana
                    winPanel.SetActive(true);
                    restartButton.gameObject.SetActive(true);
                    Time.timeScale = 0;
                }

            }
        }
    }

    public void Dead()
    {
        lives--;
        if(lives <=0 ) 
        {
            //Game Over
            loosePanel.SetActive(true);
            restartButton.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            ball.BallReady();
            gamePending = false;
        }
        UpdateUI();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    void UpdateUI()
    {
        textZycie.text = "¯ycie: " + lives.ToString();
        klockiText.text = "Klocki: " + generator.Klocki.ToString();
        levelText.text = "Level: " + level.ToString();
    }

    public void UsunKlocek(Klocek klocek)
    {
        generator.Usun(klocek);
        UpdateUI();
    }
}
