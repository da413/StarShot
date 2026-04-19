using System.Collections.Generic;

using UnityEngine;

public class BulletPool : MonoBehaviour, IObjectPool
{
    List<GameObject> bulletList = new List<GameObject>();
    public List<GameObject> ActiveBullets = new List<GameObject>();

    [SerializeField] int poolSize;
    [SerializeField] GameObject bulletRef;

    GameObject newBullet;

    GameObject bulletSave;

    float leftX, rightX, topY, bottomY;

    void Start()
    {
        float zDist = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);

        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, zDist));
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, zDist));

        leftX = bottomLeft.x;
        rightX = topRight.x;
        bottomY = bottomLeft.y;
        topY = topRight.y;
    }

    void FixedUpdate()
    {
        for (int i = ActiveBullets.Count - 1; i >= 0; i--)
        {
            GameObject bullet = ActiveBullets[i];
            Vector3 pos = bullet.transform.position;

            if (pos.x < leftX || pos.x > rightX || pos.y < bottomY || pos.y > topY)
            {
                bulletSave = bullet;
                AppendToBackOfPool();
            }
        }
    }
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
        bulletList.RemoveAt(0);
        ActiveBullets.Add(bulletList[0]);
        return bulletList[0];
    }

    public void AppendToBackOfPool()
    {
        bulletSave.SetActive(false);

        ActiveBullets.Remove(bulletSave);
        bulletList.Remove(bulletSave);
        bulletList.Add(bulletSave);
    }

}
