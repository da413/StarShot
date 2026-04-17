using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    [SerializeField] EnemyPool enemyPool;
    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>())
        {
            other.gameObject.SetActive(false);
            enemyPool.AppendToBackOfPool();
        }
    }
}
