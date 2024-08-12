using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using Unity.UI;
using TMPro;
using Image = UnityEngine.UI.Image;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Image livesImg;
    [SerializeField] private Sprite[] liveSprites;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI restartText;
   // [SerializeField] private bool GameObject ;
    // Start is called before the first frame update

     void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "score: " + 0;
        var liveSprite = liveSprites;
        
    }

    public void UpdateScore(int playerScore)
    {
        scoreText.text = "score: " + playerScore;
    }

    public void UpdateLives(int CurrentLives)
    {
        livesImg.sprite = liveSprites[CurrentLives];
        if (CurrentLives == 0)
        {
            GameOverSequence();
        }
    }

    void GameOverSequence()
    {
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerCoRoutine());
    }

    IEnumerator GameOverFlickerCoRoutine()
    {
        while (true)
        {
            gameOverText.text = "GAME OVER";
                yield return new WaitForSeconds(0.5f);
                gameOverText.text = " ";
                yield return new WaitForSeconds(0.5f);
        }
    }

}
