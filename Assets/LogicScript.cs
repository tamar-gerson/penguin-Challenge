using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    [SerializeField] private int playerScore;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject gameOverScreen;
    
    [ContextMenu("Inc")]
    public void addScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        Debug.Log("Restarting game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        gameOverScreen.SetActive(true);
    }
    
    public int getScore()
    {
        return playerScore;
    }
    
}
