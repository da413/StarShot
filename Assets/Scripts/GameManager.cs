using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] Enemy enemy;

    public int health {get; private set;} = 5;

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

    
}
