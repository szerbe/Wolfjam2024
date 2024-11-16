using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    void Start(){
    }
    void Update(){
        float horizontal = 0.0f;
        float vertical = 0.0f;
        char rotate = 'N';
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            horizontal = -1.0f;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            horizontal = 1.0f;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            vertical = 1.0f;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            vertical = -1.0f;
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            rotate = 'Q';
        }
        if(Input.GetKeyDown(KeyCode.E)){
            rotate = 'E';
        }
        Vector2 position = transform.position;
        position.x = position.x + horizontal;
        position.y = position.y + vertical;
        transform.position = position;


        void rotateDir(char rotate){
            if(rotate == 'N'){
                return;
            }
            if(rotate == 'c'){
                
            }
        }
    }
}
