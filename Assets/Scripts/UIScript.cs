/*
Author: Kyle Peniston
Date: 10/10/2024
Description: The UI script handles the game UI. Win/Lose text, timer, restart button. 
Also tracks the amount of teapots hit for win event.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    //Globals
    public Button restartButton;
    private bool hasWon = false;
    private bool hasLost = false;

    //Timer/Text Vars
    public Text countText;
    private int count;
    public Text winText;
    float timer = 30.0f;
    private int totalPickups;

    void Start()
    {
        //Set Defaults
        count = 0;
        countText.text = "Count: " + count.ToString();
        totalPickups = GameObject.FindGameObjectsWithTag("Pickup").Length;
        winText.text = "";

        restartButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!hasWon)
        {
            timer -= Time.deltaTime;
            //Doesn't alow timer doesn't go negative
            timer = Mathf.Clamp(timer, 0, float.MaxValue);
            int seconds = Mathf.CeilToInt(timer);
            countText.text = "Timer: " + seconds.ToString() + "s";

            //Times up Game Over
            if (seconds == 0)
            {
                winText.text = "Game Over!";
                restartButton.gameObject.SetActive(true);
                hasLost = true;
            }
        }
    }

    private void HandleWin()
    {
        //Set the win flag
        hasWon = true;
        winText.text = "You Win!";
        restartButton.gameObject.SetActive(true);
    }

    public void OnTeapotHit()
    {
        //Keep track of teapots hit and trigger win event
        if (!hasWon && !hasLost)
        {
            count++;

            if (count >= totalPickups)
            {
                HandleWin();
            }
        }
    }

    public void OnRestartButtonPress()
    {
        //Reset scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
