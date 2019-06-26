using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lives : MonoBehaviour
{
    private int life;
    [SerializeField] Text livesText;
    private int score;
    [SerializeField] Text scoreText;
    private void Start()
    {
        life = 3;
        score = 0;
        livesText.text = "Lives: " + life;
        scoreText.text = "Score: " + score;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "bad")
        {
            life--;
            livesText.text = "Lives: " + life;
        }
        else if (other.tag == "good")
        {
            score++;
            scoreText.text = "Score: " + score;
        }
    }

    public int GetLives()
    {
        return life;
    }
}
