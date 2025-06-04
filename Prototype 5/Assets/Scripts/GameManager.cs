using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public float spawnFrequency = 1.0f;
    public TextMeshProUGUI scoreText;
    public Button restartBtn;
    private int score;
    public bool isGameActive;
    public int finalScore;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI finalScoreText;
    public Button easyBtn;
    public Button medBtn;
    public Button hardBtn;
    public TextMeshProUGUI titleTxt;
    private Difficulty difficulty;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnFrequency);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreText.text = "Score : " + score;
        finalScore = score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        finalScoreText.text = "Score : " + finalScore;
        scoreText.gameObject.SetActive(false);
        finalScoreText.gameObject.SetActive(true);
        isGameActive = false;
        restartBtn.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        easyBtn.gameObject.SetActive(false);
        medBtn.gameObject.SetActive(false);
        hardBtn.gameObject.SetActive(false);
        titleTxt.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        spawnFrequency /= difficulty;
    }

}
