using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputActionReference moveAction;
    [SerializeField] InputActionReference shootAction;

    [SerializeField] Transform bulletSpawner;
    [SerializeField] BulletPool bulletPool;
    //GameObject bullet;
    public float speed;

    public Collider2D collider;

    private void TriggerShoot(InputAction.CallbackContext context) => Fire();
    void OnEnable()
    {
        moveAction.action.Enable();
        
        
        shootAction.action.performed += TriggerShoot;
        shootAction.action.Enable();
    }

    void OnDisable()
    {
        moveAction.action.Disable();
        shootAction.action.performed -= TriggerShoot;
        shootAction.action.Disable();
    }
   
    void FixedUpdate()
    {
        if (moveAction.action.ReadValue<Vector2>() != Vector2.zero)
            Move();
    }

    void Move()
    {
        //Debug.Log("Moving!");
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        Vector3 pos = transform.position;
        pos += (Vector3)input * speed * Time.deltaTime;

        float zDist = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);

        Vector3 camMin = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, zDist));
        Vector3 camMax = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, zDist));

        // extents
        Bounds b = collider.bounds;
        float halfW = b.extents.x;
        float halfH = b.extents.y;

        // Clamp using bounds
        pos.x = Mathf.Clamp(pos.x, camMin.x + halfW, camMax.x - halfW);
        pos.y = Mathf.Clamp(pos.y, camMin.y + halfH, camMax.y - halfH);

        transform.position = pos;
    }



    void Fire()
    {
       //Debug.Log("Fire!");
        
       bulletPool.GetFrontOfPool().transform.position =  bulletSpawner.transform.position;
       //bullet.transform.Translate(Vector2.right, Space.Self);
       
    }
}
