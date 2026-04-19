using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 20.0f;
    public float damage = 1f;

    // Update is called once per frame

    private void FixedUpdate()
    {
        transform.position += Vector3.right * speed * Time.fixedDeltaTime;
    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if(other.GetComponent<Enemy>())
    //     {
    //         gameObject.SetActive(false);
    //     }
    //}
}

