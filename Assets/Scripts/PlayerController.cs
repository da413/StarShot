using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputActionReference moveAction;
    Rigidbody2D rb_player;
    Vector2 moveValue;
    public float speed;
   
    void OnEnable()
    {
        moveAction.action.Enable();
    }

    void OnDisable()
    {
        moveAction.action.Disable();
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
}
