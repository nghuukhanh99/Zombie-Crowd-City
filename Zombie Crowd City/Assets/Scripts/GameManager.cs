using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameActive = false;

    public GameObject ScorePlayer;

    public GameObject ResumeButton;

    public GameObject SettingButton;

    public GameObject PlayButton;

    public GameObject FAQButton;

    public GameObject PlayerGameObject;

    public GameObject BotOfPlayer;

    public GameObject PlayerScoreBoard;

    public GameObject TitleGame;

    public GameObject WinGameBoard;

    public GameObject restartButton;

    public GameObject GameOverBoard;

    public GameObject FaqGame;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        Time.timeScale = 0;
    }

    
    void Update()
    {
        LoseGame();
        WinGame();


    }

    public void WinGame()
    {
        if(BlueAIScripts.Instance.NumberScore <= 0 && GreenAiScripts.Instance.NumberScore <= 0)
        {
            if(YellowAIScripts.Instance.NumberScore <= 0 && OrangeAIScripts.Instance.NumberScore <= 0)
            {
                Time.timeScale = 0;

                WinGameBoard.SetActive(true);
            }
            
        }
    }

    public void LoseGame()
    {
        if(PlayerController.Instance.NumberScore <= 0)
        {
            
        }
    }

    public void SettingGame()
    {
        Time.timeScale = 0;


        SettingButton.gameObject.SetActive(false);

        ResumeButton.gameObject.SetActive(true);

        restartButton.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;

        SettingButton.gameObject.SetActive(true);

        ResumeButton.gameObject.SetActive(false);
    }

    public void StartGame()
    {

        Time.timeScale = 1;

        PlayButton.SetActive(false);

        FAQButton.SetActive(false);

        TitleGame.SetActive(false);

        isGameActive = true;
    }

    public void GameOver()
    {
        Time.timeScale = 0;

        restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void FAQButtonClick()
    {
        FaqGame.SetActive(true);
    }
}
