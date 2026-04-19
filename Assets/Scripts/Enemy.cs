using System;
using UnityEngine;
public class Enemy : MonoBehaviour
{
   [SerializeField] float speed;
   float hitpoints = 1f;
   [SerializeField] int points = 5;

   public static event Action OnEnemyDestroyed;

   public int damage {get; private set;} = 1; //amount of damage done to player health

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        transform.position += Vector3.left * speed * Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.GetComponent<Bullet>()){
         
         hitpoints -= other.GetComponent<Bullet>().damage;
         
         if(hitpoints <= 0)
            {
                //Debug.Log(hitpoints);
                gameObject.SetActive(false);
                OnEnemyDestroyed?.Invoke();
            }
         
       }
       
    }

    public int GetPointValue()
    {
        return points;
    }
}
