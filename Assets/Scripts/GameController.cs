using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// tao ra cac enemy o nhung vi tri ngau nhien tren man hinh 
// tang diem so khi ha guc enemy
// kiem tra game over

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime ;
    float m_spawnTime;
    int m_score;
    bool m_isGameOver;

    UIManager m_ui;

    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0 ;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.SetScoreText("Score : "+ m_score);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_isGameOver){
            m_ui.ShowGameOverPanel(true);
            m_spawnTime = 0;
            return;
        }

        m_spawnTime -= Time.deltaTime;
        if(m_spawnTime <= 0){
            SpawnEnemy();

            m_spawnTime = spawnTime;
        }
    }

    public void SpawnEnemy(){
        
        float randxPos = Random.Range(-5.1f , 8.2f); 
        
        float randyPos = Random.Range(4.6f , 3.7f) ;

        Vector2 spawnPos = new Vector2(randxPos, randyPos);

        if(enemy){
            Instantiate(enemy, spawnPos , Quaternion.identity);
        }
    }

    // score
    public void SetScore(int value){
        m_score = value;
    }

    public int GetScore(){
        return m_score;
    }
    
    public void ScoreIncrement(){
        if(m_isGameOver){
            return;
        }
        m_score ++;
        m_ui.SetScoreText("Score : " + m_score);
    }

    // set game over

    public void SetGameOverState(bool state){
        m_isGameOver = state;
    }

    public bool IsGameOver(){
        return m_isGameOver;
    }

    public void Replay(){
        SceneManager.LoadScene("GamePlay");
    }

}
