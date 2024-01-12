using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class LogicScript : MonoBehaviour
{
    [SerializeField] private int playerScore;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private spawnerScript fishSpawner;
    [SerializeField] private Tilemap tilemap;
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
    
    public void crazyMode(int crazyTime)
    {
        Debug.Log("crazy mode");
        StartCoroutine(CrazyModeCoroutine(crazyTime));
    }
    
    private IEnumerator CrazyModeCoroutine(int crazyTime)
    {
        float originalSpwanRate = fishSpawner.getSpawnRate();
        fishSpawner.setSpawnRate(originalSpwanRate/ 3); 
        tilemap.color = Color.red;

        // Wait for specified seconds
        yield return new WaitForSeconds(crazyTime);

        // Do something else after 7 seconds
        fishSpawner.setSpawnRate(originalSpwanRate); 
        tilemap.color = Color.white;
    }
    
}
