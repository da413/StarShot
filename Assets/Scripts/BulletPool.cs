using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BulletPool : MonoBehaviour, IObjectPool
{
    List<GameObject> bulletList = new List<GameObject>();
    [SerializeField] int poolSize;
    [SerializeField] GameObject bulletRef;

    GameObject newBullet;

    GameObject bulletSave;

    void Awake()
    {
        //intialize the pool
       for(int i = 0; i<poolSize; ++i)
        {
            newBullet = Instantiate(bulletRef);
            newBullet.SetActive(false);

            bulletList.Add(newBullet);
        }
    }
    

    public GameObject GetFrontOfPool()
    {
        bulletList[0].SetActive(true);
        return bulletList[0];
    }
    public void AppendToBackOfPool()
    {
        bulletSave = bulletList[0];
       // bulletSave.SetActive(false);
        bulletList.RemoveAt(0);
        bulletList.Add(bulletSave);
    }
}
