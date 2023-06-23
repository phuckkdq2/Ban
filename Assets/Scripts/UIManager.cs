using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    public GameObject gameOverPanel;
    public Text scoreText;

    public void SetScoreText(string txt){
        if(scoreText){
            scoreText.text = txt;
        }
    }

    public void ShowGameOverPanel(bool isShow){
        if(gameOverPanel){
            gameOverPanel.SetActive(isShow);
        }
    }
    
}
