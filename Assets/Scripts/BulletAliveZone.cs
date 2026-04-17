using UnityEngine;

public class BulletAliveZone : MonoBehaviour
{
    [SerializeField] BulletPool bulletPool;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bullet>())
        {
          //  Debug.Log("Triggered!");
            bulletPool.AppendToBackOfPool();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Bullet>())
        {
           // Debug.Log("disabled!");
            other.gameObject.SetActive(false);
        }
    }
}
