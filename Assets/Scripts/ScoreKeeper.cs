using UnityEngine;
using TMPro;
using System;


public class ScoreKeeper : MonoBehaviour
{
    int score = 0;
    int winScore = 500;
    [SerializeField] Enemy enemy;

    [SerializeField] TextMeshProUGUI scoreText;
    public static event Action OnWinScoreAcquired;
    void OnEnable()
    {
        Enemy.OnEnemyDestroyed += AddScore;
    }

    void OnDisable()
    {
        Enemy.OnEnemyDestroyed -= AddScore;
    }

    void Start()
    {
        UpdateScoreUI();
      //  Debug.Log(enemy.points);
    }

    void AddScore()
    {
        score += enemy.GetPointValue();
        Debug.Log(score);
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
       scoreText.text = score.ToString();
       if(score >= winScore)
        {
            OnWinScoreAcquired?.Invoke();
        }
    }
}
