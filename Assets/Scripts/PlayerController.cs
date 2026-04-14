using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputAction moveAction;
    Transform playertransform;
    Vector2 moveValue;
    public float speed;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        playertransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        
        playertransform.Translate(moveValue*speed*Time.deltaTime, Space.Self);
        
    }
}
