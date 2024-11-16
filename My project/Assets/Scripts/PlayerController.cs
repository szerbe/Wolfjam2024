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
        if(canMove('l') && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))){
            horizontal = -1.0f;
        }
        //Move right
        if(canMove('r') && (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))){
            horizontal = 1.0f;
        }

        //Move up
        if(canMove('u') && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))){
            vertical = 1.0f;
        }

        //Move down
        if(canMove('d') && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))){
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
        if(Input.GetKeyDown(KeyCode.Return)){
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
    void rotateDir(char rotate){
        if(rotate == 'N'){
            return;
        }
        else if(rotate == 'Q'){ //&& canRotate('l')
            transform.RotateAround(rotationPoint.transform.position, Vector3.forward, 90);
            return;
        }
        else if(rotate == 'E'){ //&& canRotate('r')
            transform.RotateAround(rotationPoint.transform.position, Vector3.forward, -90);
            return;
        }
    }

    bool canMove(char direction){
        List<Vector2> player = Block.getAttachedBlocks();
        List<Vector2> walls = Block.getWalls();
        for(int i = 0; i < player.Count; i++){
            Vector2 location = player[i];
            if(direction.Equals('l')){
                location.x -= 1;
            }
            if(direction.Equals('r')){
                location.x += 1;
            }
            if(direction.Equals('u')){
                location.y += 1;
            }
            if(direction.Equals('d')){
                location.y -= 1;
            }
            for(int j = 0; j < walls.Count; j++){
                if(walls.Contains(location)){
                    return false;
                }
            }
        }
        return true;
    }

    bool canRotate(char direction){
        List<Vector2> player = Block.getAttachedBlocks();
        List<Vector2> walls = Block.getWalls();
        double theta = 90;
        if(direction.Equals('r')){
            theta = -90;
        }
        float cosX = (float)Math.Cos(theta);
        float sinX = (float)Math.Sin(theta);
        Vector2[] matrix = {new Vector2(cosX, -sinX), new Vector2(sinX, cosX)};

        for(int i = 0; i < player.Count; i++){
            Vector2 location = player[i];
            location = new Vector2(matrix[0].x*player[i].x + matrix[0].y*player[i].y, matrix[1].x*player[i].x + matrix[1].y*player[i].y);
            for(int j = 0; j < walls.Count; j++){
                if(walls.Contains(location)){
                    return false;
                }
            }
        }
        return true;
    }
}
