using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{
    public GameObject menuBar;
    public int intScore;
    public Text score;
    
    public GameObject gameOverScreen;
    public int intRecord;
    public Text totalScore;
    public Text record;
    
    [SerializeField] private AudioSource effect;

    [ContextMenu("addScore")]
    public void AddScore()
    {
        if (gameOverScreen.activeInHierarchy)
            return;
        ++intScore;
        score.text = intScore.ToString();
        
        if (intScore % 10 == 0)
            effect.Play();
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("record") == false)
            PlayerPrefs.SetInt("record", intRecord);
        else
            intRecord = PlayerPrefs.GetInt("record");
        menuBar.SetActive(true);
        gameOverScreen.SetActive(false);
    }
    
    public void GameOver()
    {
        if (intRecord < intScore)
        {
            intRecord = intScore;
            record.color = new Color(0.52f, 0, 0.11f);
        }
        else
            record.color = new Color(0.61f, 0.61f, 0.61f);

        menuBar.SetActive(false);
        totalScore.text = score.text;
        record.text = intRecord.ToString();
        gameOverScreen.SetActive(true);
        
        if (PlayerPrefs.GetInt("record") < intRecord)
            PlayerPrefs.SetInt("record", intRecord);
        PlayerPrefs.Save();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
