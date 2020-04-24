using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private bool gameHasEnded = false;

    private SpriteRenderer spriteR;

    public InventoryObject[] inventory;
    public int currentIndex = 0;

    public GameObject gameOverUI;
    public GameObject gameStartUI;
    public GameObject shopUI;

    public GameObject player;

    public Button playAgainButton;
    public Button playGameButton;

    public Button shopButton;
    public Button backButton;
    private void Start()
    {
        spriteR = player.GetComponent<SpriteRenderer>();

        spriteR.sprite = inventory[currentIndex].playerSprite;

        Button playAgain = playAgainButton.GetComponent<Button>();
        Button playGame = playGameButton.GetComponent<Button>();

        Button shopBtn = shopButton.GetComponent<Button>();
        Button backBtn = backButton.GetComponent<Button>();
        playAgain.onClick.AddListener(TaskOnClick);
        playGame.onClick.AddListener(PlayGameOnClick);

        shopBtn.onClick.AddListener(LaunchShop);
        backBtn.onClick.AddListener(BackToGame);

    }

    private void BackToGame()
    {
        shopUI.SetActive(false);
        gameStartUI.SetActive(true);
    }

    private void LaunchShop()
    {
        shopUI.SetActive(true);
        gameStartUI.SetActive(false);
    }

    private void PlayGameOnClick()
    {
        gameStartUI.SetActive(false);
        FindObjectOfType<AdsManager>().RequestInterstitial();
        FindObjectOfType<Player>().isGameStarted = true;

        // SceneManager.LoadScene("MainScene");
    }

    private void TaskOnClick()
    {
        SceneManager.LoadScene("MainScene");
        FindObjectOfType<AdsManager>().ShowInterstitial();
    }

    public void GameEndedUI()
    {
        gameOverUI.SetActive(true);
    }

	public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            GameEndedUI();
        }
    }
}
