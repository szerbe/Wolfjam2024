using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction LeftAction;
    public InputAction RightAction;
    public InputAction UpAction;
    public InputAction DownAction;
    void Start(){
        LeftAction.Enable();
        RightAction.Enable();
        UpAction.Enable();
        DownAction.Enable();
    }

    void Update(){
        float horizontal = 0.0f;
        float vertical = 0.0f;
        if(LeftAction.IsPressed()){
            horizontal = -1.0f;
        }
        if(RightAction.IsPressed()){
            horizontal = 1.0f;
        }
        if(UpAction.IsPressed()){
            vertical = 1.0f;
        }
        if(DownAction.IsPressed()){
            vertical = -1.0f;
        }
        Vector2 position = transform.position;
        position.x = position.x + 0.1f * horizontal;
        position.y = position.y + 0.1f * vertical;
        transform.position = position;
    }
}
