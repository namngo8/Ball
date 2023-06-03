using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    public double spawnTime;
    public GameObject line;

    UIManager uIManager;
    double p_spawnTime, saveSpawTime;
    int score;
    bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
        uIManager.SetTxtScore("Score: "+score);
        p_spawnTime = 0;
        saveSpawTime = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver())
        {
            spawnLine(false);
            p_spawnTime = 0;
            uIManager.ShowGameOverPanel(true);
            if (line)
            {
                line.SetActive(false);
            }
            return;
        }
        p_spawnTime -= Time.deltaTime;
        if (p_spawnTime < 0)
        {
            SpawnBall();
            p_spawnTime = spawnTime;
            if (spawnTime > 0.4)
            {
                spawnTime -= 0.1;
            }
        }
    }

    public void SpawnBall()
    {
        Vector2 newBall = new Vector2(Random.Range(-2, 2), 6);
        if (ball)
        {
            Instantiate(ball, newBall, Quaternion.identity);
        }
    }

    public void PlayAgain()
    {
        spawnLine(true);
        score = 0;
        spawnTime = saveSpawTime;
        gameOver = false;
        uIManager.SetTxtScore("Score: " + score);
        uIManager.ShowGameOverPanel(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        SceneManager.UnloadSceneAsync(1);
    }

    public void spawnLine(bool status)
    {
        if (line)
        {
            line.SetActive(status);
        }
    }

    public double getSpawnTime()
    {
        return p_spawnTime;
    }

    public void setSpawnTime(float value)
    {
        p_spawnTime = spawnTime;
    }

    public int getScore()
    {
        return score;
    }

    public void setScore(int value)
    {
        score = value;
    }

    public void upScore()
    {
        score++;
        uIManager.SetTxtScore("Score: " + score);
    }

    public bool isGameOver()
    {
        return gameOver;
    }

    public void setGameOver(bool value)
    {
        gameOver = value;
    }
}
