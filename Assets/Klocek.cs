using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Klocek : MonoBehaviour
{
    public int lives = 1;
    public Color[] colors = { Color.gray, Color.blue, Color.green };

    static readonly int maxLives = 3;

    private void Start()
    {
      
        SetKlocek(lives);
    }

    public void SetKlocek(int lives)
    {
        this.lives = lives;
        this.lives = Mathf.Clamp(lives, 0, maxLives);
        SetColor();
    }

    void SetColor()
    {
        Color color = colors[lives - 1];
        GetComponent<Renderer>().material.color = color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Ball"))
        {
            lives--;
            if(lives > 0)
            {
                SetColor();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
