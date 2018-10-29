using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool gameStarted;
    public int score;
    public int highscore;

    public AudioSource crystalAudio;
    public Text scoreText;
    public Text highscoreText;

    private void Start()
    {
        crystalAudio = GetComponent<AudioSource>();
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        highscoreText.text = "Best: " + highscore;
    }

    public void StartGame()
    {
        FindObjectOfType<Road>().StartBuilding();
        highscoreText.text = score.ToString();
        gameStarted = true;
    }

    public void RestartGame()
    {
        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
            StartGame();
	}

    public void IncrementScore()
    {
        crystalAudio.Play();
        score++;
        scoreText.text = score.ToString();
        highscoreText.text = score.ToString();
    }
}
