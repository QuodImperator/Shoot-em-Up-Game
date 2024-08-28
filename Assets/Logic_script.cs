using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logic_script : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public int playerHealth;
    public GameObject GameOverScreen;

    void Start()
    {
        playerHealth = 2;
    }

    public void addScore()
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        GameOverScreen.SetActive(true);
    }
}
