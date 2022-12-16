using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    public Text textScore;
    public GameObject playButton;
    public GameObject gameOver;
    public Player player;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();

    }
    public void GameOver()
    {
        Pause();
        gameOver.SetActive(true);
        playButton.SetActive(true);
    }
    public void Play()
    {
        player.enabled = true;
        Time.timeScale = 1f;
        gameOver.SetActive(false);
        playButton.SetActive(false);
        score = 0;
        textScore.text = score.ToString();

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        foreach (Pipes pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f; // makes Time.deltaTime = 0 which will stop any mouvement based on the time
        player.enabled = false;
    }
    public void IncreaseScore()
    {
        score++;
        textScore.text = score.ToString();
    }
}
