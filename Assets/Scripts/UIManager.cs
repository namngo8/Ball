using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text txtScore;
    public GameObject gameOverPanel;

    public void SetTxtScore(string txt)
    {
        if (txtScore)
        {
            txtScore.text = txt;
        }
    }

    public void ShowGameOverPanel(bool isShow)
    {
        if (gameOverPanel)
        {
            gameOverPanel.SetActive(isShow);
        }
    }
}
