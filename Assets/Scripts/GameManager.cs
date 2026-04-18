using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] Enemy enemy;


    void Awake()
    {
       if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
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
    }
    void OnDisable()
    {
        PlayerHealth.onPlayerDeath -= GameOver;
    }

    void GameOver()
    {
        Debug.Log("Game over!");
        PlayerHealth.onPlayerDeath -= GameOver;
    }

    
}
