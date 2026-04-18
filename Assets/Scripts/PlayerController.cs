
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputActionReference moveAction;
    [SerializeField] InputActionReference shootAction;
    Rigidbody2D rb_player;
    Vector2 moveValue;
    [SerializeField] Transform bulletSpawner;
    [SerializeField] BulletPool bulletPool;
    GameObject bullet;
    public float speed;

    public static event Action OnPlayerFired;
   
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
   
    void Start()
    { 
        rb_player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       moveValue = new Vector2(moveAction.action.ReadValue<Vector2>().x, moveAction.action.ReadValue<Vector2>().y);

       rb_player.MovePosition( ((Vector2) transform.position) + moveValue * Time.fixedDeltaTime * speed);
       
        
    }

    void Fire()
    {
       //Debug.Log("Fire!");
       OnPlayerFired?.Invoke();
       bulletPool.GetFrontOfPool().transform.position =  bulletSpawner.transform.position;
       //bullet.transform.Translate(Vector2.right, Space.Self);
       
    }
}
