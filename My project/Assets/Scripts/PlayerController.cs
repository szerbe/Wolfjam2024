using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private GameObject rotationPoint = null;
    void Start(){
        if(rotationPoint == null){
            rotationPoint = GameObject.FindGameObjectWithTag("Player");
        }
    }
    void Update(){
        float horizontal = 0.0f;
        float vertical = 0.0f;
        char rotate = 'N';
        bool confirm = false;
        

        //Move left
        if((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && Block.canMove('l')){
            horizontal = -1.0f;
        }
        //Move right
        if((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && Block.canMove('r')){
            horizontal = 1.0f;
        }

        //Move up
        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && Block.canMove('u')){
            vertical = 1.0f;
        }

        //Move down
        if((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && Block.canMove('d')){
            vertical = -1.0f;
        }

        //Rotate counterclockwise
        if(Input.GetKeyDown(KeyCode.Q)){
            rotate = 'Q';
            rotateDir(rotate);
        }

        //Rotate clockwise
        if(Input.GetKeyDown(KeyCode.E)){
            rotate = 'E';
            rotateDir(rotate);
        }

        //Confirm choices (level select, attachment, removal)
        if(Input.GetKeyDown(KeyCode.Space)){
            levelInit one = new levelInit(1);
        }
        if(Input.GetKeyDown(KeyCode.Return)){
            Debug.Log("Enter key pressed");
            this.GetComponent<Block>().unmerge();
            this.GetComponent<Block>().merge();
        }
        if(Input.GetKeyDown(KeyCode.Alpha1)||Input.GetKeyDown(KeyCode.Keypad1)){
            levelInit one = new levelInit(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)||Input.GetKeyDown(KeyCode.Keypad2)){
            levelInit one = new levelInit(2);
            // confirm = true;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)||Input.GetKeyDown(KeyCode.Keypad3)){
            levelInit one = new levelInit(3);
            // confirm = true;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)||Input.GetKeyDown(KeyCode.Keypad4)){
            levelInit one = new levelInit(4);
            // confirm = true;
        }
        if(Input.GetKeyDown(KeyCode.Alpha5)||Input.GetKeyDown(KeyCode.Keypad5)){
            levelInit one = new levelInit(5);
            // confirm = true;
        }
        //Spawn more tiles (debug)
        if(Input.GetKeyDown(KeyCode.P)){
            if(!(this.GetComponent<Block>().getDown())){
                this.GetComponent<Block>().attach("DOWN", "blueTile.png");
            }
            if(!(this.GetComponent<Block>().getRight())){
                this.GetComponent<Block>().attach("RIGHT", "greenTile.png");
            }
            if(!(this.GetComponent<Block>().getLeft())){
                this.GetComponent<Block>().attach("LEFT", "tile2.png");
            }
            if(!(this.GetComponent<Block>().getUp())){
                this.GetComponent<Block>().attach("UP", "redTile.png");
            }

            // Debug.Log("Trying to create a sprite");
        }
        

        //Calculate movement and move

        Vector2 position = transform.position;
        position.x = position.x + horizontal;
        position.y = position.y + vertical;
        transform.position = position;


        //Does actions that require confirming
        if(confirm){
            //stuff goes here
        }
    }
    
    //Rotates the player in a direction, Q for counterclockwise, E for clockwise
    public void rotateDir(char rotate){
        if(rotate == 'N'){
            return;
        }
        else if(rotate == 'Q' && Block.canRotate('l')){
            transform.RotateAround(rotationPoint.transform.position, Vector3.forward, 90);
            int XPos = (int) Math.Round(transform.position.x);
            int YPos = (int) Math.Round(transform.position.y);
            transform.position = new Vector2(XPos, YPos);
            return;
        }
        else if(rotate == 'E' && Block.canRotate('r')){
            transform.RotateAround(rotationPoint.transform.position, Vector3.forward, -90);
            int XPos = (int) Math.Round(transform.position.x);
            int YPos = (int) Math.Round(transform.position.y);
            transform.position = new Vector2(XPos, YPos);
            return;
        }
    }

}
