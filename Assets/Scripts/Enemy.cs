using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] float speed;
   float hitpoints = 1f;

    Rigidbody2D rb_enemy;

    void Awake()
    {
        rb_enemy = GetComponent<Rigidbody2D>();
  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb_enemy.MovePosition((Vector2) gameObject.transform.position + Vector2.left * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.GetComponent<Bullet>()){
         
         hitpoints -= other.GetComponent<Bullet>().damage;
         
         if(hitpoints <= 0)
            {
                //Debug.Log(hitpoints);
                gameObject.SetActive(false);
            }
         
       }
       
    }
}
