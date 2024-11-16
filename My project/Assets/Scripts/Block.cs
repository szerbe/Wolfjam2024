using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour
{
    private char color;
    private Boolean up;
    private Boolean down;
    private Boolean left;
    private Boolean right;

    public Block(char c){
        up = false;
        down = false;
        left = false;
        right = false;
        //'r' = Red = subtract
        //'g' = Green = merge
        //'b' = Black = obstacle (cannot overlap)
        //'c' = Blue = character (subclass)
        //'y' = key = win condition
        //'e' = Empty = no tile
        color = c;
    }
    
    public char getColor(){
        return color;
    }

    public bool getDown(){
        return down;
    }
    public bool getRight(){
        return right;
    }
    public bool getLeft(){
        return left;
    }
    public bool getUp(){
        return up;
    }

    public void setDown(bool d){
        down = d;
    }
    public void setLeft(bool l){
        left = l;
    }
    public void setRight(bool r){
        right = r;
    }
    public void setUp(bool u){
        up = u;
    }
    /* Attaches another block to this
    * @param dir - direction to attach to, "DOWN", "UP", "RIGHT", "LEFT"
    * @param spr - sprite name of sprite to attach, full sprite name before last .png
    */
    public void attach(String dir, String spr){
        // Debug.Log("Method Called!");
        var GameObject = new GameObject();
        var SpriteRenderer = GameObject.AddComponent<SpriteRenderer>();
        var texture = Resources.Load<Texture2D>("Art/Tiles/" + spr);
        
        if(dir.Equals("DOWN") && !down){
            if(texture != null){
                down = true;
                // Debug.Log("Condition Met");
                SpriteRenderer.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 64);
                Vector2 position = GameObject.transform.position;
                position.x = this.transform.position.x;
                position.y = this.transform.position.y - 1;
                GameObject.transform.position = position;
                GameObject.AddComponent<PlayerController>();
                GameObject.AddComponent<Block>();
                GameObject.GetComponent<Block>().setUp(true);

            }
            else {
                Debug.Log("Texture Not Found");
            }
        }

        else if(dir.Equals("RIGHT") && !right){
            if(texture != null){
                right = true;
                // Debug.Log("Condition Met");
                SpriteRenderer.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 64);
                Vector2 position = GameObject.transform.position;
                position.x = this.transform.position.x + 1;
                position.y = this.transform.position.y;
                GameObject.transform.position = position;
                GameObject.AddComponent<PlayerController>();
                GameObject.AddComponent<Block>();
                GameObject.GetComponent<Block>().setLeft(true);

            }
            else {
                Debug.Log("Texture Not Found");
            }
        }

        else if(dir.Equals("UP") && !up){
            if(texture != null){
                up = true;
                // Debug.Log("Condition Met");
                SpriteRenderer.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 64);
                Vector2 position = GameObject.transform.position;
                position.x = this.transform.position.x;
                position.y = this.transform.position.y + 1;
                GameObject.transform.position = position;
                GameObject.AddComponent<PlayerController>();
                GameObject.AddComponent<Block>();
                GameObject.GetComponent<Block>().setDown(true);

            }
            else {
                Debug.Log("Texture Not Found");
            }
        }
        
        else if(dir.Equals("LEFT") && !left){
            if(texture != null){
                left = true;
                // Debug.Log("Condition Met");
                SpriteRenderer.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 64);
                Vector2 position = GameObject.transform.position;
                position.x = this.transform.position.x - 1;
                position.y = this.transform.position.y;
                GameObject.transform.position = position;
                GameObject.AddComponent<PlayerController>();
                GameObject.AddComponent<Block>();
                GameObject.GetComponent<Block>().setRight(true);
            }
            else {
                Debug.Log("Texture Not Found");
            }
        }

        else{
            Debug.Log("Block could not be created" + dir + "of block at " + transform.position);
        }
    }
}
