using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    [SerializeField] EnemyPool enemyPool;
    [SerializeField] Enemy enemy;
    [SerializeField] PlayerHealth playerHealth;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>())
        {
            other.gameObject.SetActive(false);
            enemyPool.AppendToBackOfPool();

            playerHealth.TakeDamage(other.GetComponent<Enemy>().damage);

        }
    }
}
