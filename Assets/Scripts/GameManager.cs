using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] Enemy enemy;
    [SerializeField] GameObject loseUI;
    [SerializeField] GameObject winUI;

    void Awake()
    {
       if (instance == null)
        {
            instance = this;
          //  DontDestroyOnLoad(gameObject);
        }
        else
        {
        // A GameManager already exists, kill this impostor!
            Destroy(gameObject); 
        }

        
    }

   
    void OnEnable()
    {
        PlayerHealth.onPlayerDeath += GameOver;
        ScoreKeeper.OnWinScoreAcquired += Win;
    }
    void OnDisable()
    {
        PlayerHealth.onPlayerDeath -= GameOver;
        ScoreKeeper.OnWinScoreAcquired -= Win;
    }

    void GameOver()
    {
        Debug.Log("Game over!");
        Time.timeScale = 0;
        loseUI.SetActive(true);//display lose menu
       // PlayerHealth.onPlayerDeath -= GameOver;
    }

    void Win()
    {
        Debug.Log("You win!");
        Time.timeScale = 0;
        winUI.SetActive(true);//display win menu
      //  ScoreKeeper.OnWinScoreAcquired -= Win;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    
}
