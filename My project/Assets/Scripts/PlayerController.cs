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
        GameObject rotationPoint = GameObject.FindWithTag("Player");
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
            horizontal = -1.0f;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)){
            horizontal = 1.0f;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)){
            vertical = 1.0f;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)){
            vertical = -1.0f;
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            rotate = 'Q';
            rotateDir(rotate);
        }
        if(Input.GetKeyDown(KeyCode.E)){
            rotate = 'E';
            rotateDir(rotate);
        }
        if(Input.GetKeyDown(KeyCode.P)){
            if(!(this.GetComponent<Block>().getDown())){
                this.GetComponent<Block>().attach(0, "blueTile.png");
                this.GetComponent<Block>().attach(1, "greenTile.png");
                this.GetComponent<Block>().attach(2, "redTile.png");
                this.GetComponent<Block>().attach(3, "tile2.png");
            }
            Debug.Log("Trying to create a sprite");
        }
        Vector2 position = transform.position;
        position.x = position.x + horizontal;
        position.y = position.y + vertical;
        transform.position = position;


        void rotateDir(char rotate){
            if(rotate == 'N'){
                return;
            }
            if(rotate == 'Q'){
                transform.RotateAround(rotationPoint.transform.position, Vector3.forward, 90);
            }
            if(rotate == 'E'){
                transform.RotateAround(rotationPoint.transform.position, Vector3.forward, -90);
            }
        }
    }
}
