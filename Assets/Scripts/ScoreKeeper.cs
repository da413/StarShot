using UnityEngine;
using TMPro;


public class ScoreKeeper : MonoBehaviour
{
    int score = 0;
    int winScore = 500;
    [SerializeField] Enemy enemy;

    [SerializeField] TextMeshProUGUI scoreText;
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
    }
}
