using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour, IObjectPool
{
   
   List<GameObject> EnemyList = new List<GameObject>();
   [SerializeField] int poolSize;
   [SerializeField] GameObject enemyRef;

   

   GameObject newEnemy;
   GameObject recycleEnemy;
   
   void Awake()
    {
       
        for(int i = 0; i < poolSize; ++i)
        {
            newEnemy = Instantiate(enemyRef);
            newEnemy.SetActive(false);

            EnemyList.Add(newEnemy);
        }
    }
   
    public void AppendToBackOfPool()
    {
        recycleEnemy = EnemyList[0];
        EnemyList.RemoveAt(0);
        EnemyList.Add(recycleEnemy);
    }

    public GameObject GetFrontOfPool()
    {
        EnemyList[0].SetActive(true);
        return EnemyList[0];
    }

}
