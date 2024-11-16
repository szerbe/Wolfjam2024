using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction LeftAction;
    public InputAction RightAction;
    void Start(){
        LeftAction.Enable();
        RightAction.Enable();
    }

    void Update(){
        float horizontal = 0.0f;
        if(LeftAction.IsPressed()){
            horizontal = -1.0f;
        }
        if(RightAction.IsPressed()){
            horizontal = 1.0f;
        }
        Vector2 position = transform.position;
        position.x = position.x + 0.1f * horizontal;
        transform.position = position;
    }
}
