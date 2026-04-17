
using System.Collections;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] RectTransform bounds;
    float randYPosition;
    Vector2 upperBound;
    Vector2 lowerBound;
    EnemyPool enemyPool;

    [SerializeField] float spawnRate; //lower value = faster spawn time

    Vector2 randPosition;
    Coroutine pickCoroutine;
    void Awake()
    {
        upperBound = new Vector2(0,bounds.rect.height/2) + Vector2.down;
        lowerBound =  new Vector2(0,-bounds.rect.height/2) + Vector2.up;
        enemyPool = GetComponent<EnemyPool>();
    }

    void Start()
    {
        pickCoroutine = StartCoroutine(PickPosition());
    }


    private IEnumerator PickPosition()
    {
        while (true)
        {
            randYPosition = Random.Range(lowerBound.y, upperBound.y);
            randPosition = new Vector2(transform.position.x, randYPosition);

            transform.position = randPosition;

            SpawnEnemy();

            yield return new WaitForSeconds(spawnRate);
        }
        
    }

    void SpawnEnemy()
    {
        enemyPool.GetFrontOfPool().transform.position = transform.position;
        enemyPool.AppendToBackOfPool();
    }
}

    
