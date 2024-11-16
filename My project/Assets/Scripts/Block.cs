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

    public Boolean getDown(){
        return down;
    }

    public void attach(int dir, String spr){
        Debug.Log("Method Called!");
        if(dir == 0 && !down){
            var GameObject = new GameObject();
            var SpriteRenderer = GameObject.AddComponent<SpriteRenderer>();
            var texture = Resources.Load<Texture2D>("Art/Tiles/" + spr);
            if(texture != null){
                down = true;
                Debug.Log("Condition Met");
                SpriteRenderer.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 64);
                Vector2 position = GameObject.transform.position;
                position.x = this.transform.position.x;
                position.y = this.transform.position.y - 1;
                GameObject.transform.position = position;
                GameObject.AddComponent<PlayerController>();
                GameObject.AddComponent<Block>();
                down = true;

            }
            else {
                Debug.Log("Not Found");
            }
        }
        if(dir == 1 && !right){
            var GameObject = new GameObject();
            var SpriteRenderer = GameObject.AddComponent<SpriteRenderer>();
            var texture = Resources.Load<Texture2D>("Art/Tiles/" + spr);
            if(texture != null){
                down = true;
                Debug.Log("Condition Met");
                SpriteRenderer.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 64);
                Vector2 position = GameObject.transform.position;
                position.x = this.transform.position.x + 1;
                position.y = this.transform.position.y;
                GameObject.transform.position = position;
                GameObject.AddComponent<PlayerController>();
                GameObject.AddComponent<Block>();
                down = true;

            }
            else {
                Debug.Log("Not Found");
            }
        }
        if(dir == 2 && !up){
            var GameObject = new GameObject();
            var SpriteRenderer = GameObject.AddComponent<SpriteRenderer>();
            var texture = Resources.Load<Texture2D>("Art/Tiles/" + spr);
            if(texture != null){
                down = true;
                Debug.Log("Condition Met");
                SpriteRenderer.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 64);
                Vector2 position = GameObject.transform.position;
                position.x = this.transform.position.x;
                position.y = this.transform.position.y + 1;
                GameObject.transform.position = position;
                GameObject.AddComponent<PlayerController>();
                GameObject.AddComponent<Block>();
                down = true;

            }
            else {
                Debug.Log("Not Found");
            }
        }
        if(dir == 3 && !left){
            var GameObject = new GameObject();
            var SpriteRenderer = GameObject.AddComponent<SpriteRenderer>();
            var texture = Resources.Load<Texture2D>("Art/Tiles/" + spr);
            if(texture != null){
                down = true;
                Debug.Log("Condition Met");
                SpriteRenderer.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 64);
                Vector2 position = GameObject.transform.position;
                position.x = this.transform.position.x - 1;
                position.y = this.transform.position.y;
                GameObject.transform.position = position;
                GameObject.AddComponent<PlayerController>();
                GameObject.AddComponent<Block>();
                down = true;

            }
            else {
                Debug.Log("Not Found");
            }
        }
    }

    

}
