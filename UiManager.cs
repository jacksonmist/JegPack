using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UiManager : MonoBehaviour
{
    public PlayerController player;
    public ZapperSpawn zapper;


    public Text scoreText;
    public Text coinAmtText;
    public Text highScoreText;
    public Text totalCoinsText;
    public float highScore;
    public int allCoins;
    public GameObject gameOverScreen;
    void Start()
    {
        allCoins = PlayerPrefs.GetInt("allCoins");
        highScore = PlayerPrefs.GetFloat("highScore");
    }

    void Update()
    {
        ScoreAndDistance();

    }

    void ScoreAndDistance()
    {
        
        coinAmtText.text = player.coins.ToString();

        scoreText.text = zapper.disTrav.ToString("0");
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
        HighScoreAndCoins();
        
    }

    void HighScoreAndCoins()
    {
        allCoins += player.coins;
        PlayerPrefs.SetInt("allCoins", allCoins);
        totalCoinsText.text = $"Total Coins: {allCoins}";

        if (zapper.disTrav > highScore)
        {
            highScore = zapper.disTrav;
            PlayerPrefs.SetFloat("highScore", highScore);
        }
        highScoreText.text = $"High Score: {highScore.ToString("0")}";
    }

   
}
