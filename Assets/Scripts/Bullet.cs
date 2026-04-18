using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 20.0f;
    Rigidbody2D rb_bullet;
    public float damage = 1f;

    // Update is called once per frame

    void Awake()
    {
        rb_bullet = GetComponent<Rigidbody2D>();

    }
    
    void OnEnable()
    {
        rb_bullet.AddForce(Vector2.right*speed, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            Debug.Log("hit enemy");
            gameObject.SetActive(false);
        }
    }
    
}
