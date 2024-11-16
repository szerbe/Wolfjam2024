using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class Block : MonoBehaviour
{
    private char color;
    private Boolean up;
    private Boolean down;
    private Boolean left;
    private Boolean right;

    private static List<Vector2> player = Block.getAttachedBlocks();
    private static List<Vector2> walls = Block.getWalls();

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

    void Update(){
        if(this.tag == "Player"){
            player = Block.getAttachedBlocks();
            walls = Block.getWalls();
        }
    }

    public static List<Vector2> getAttachedBlocks(){
        List<Vector2> positions = new List<Vector2>();
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Attached");
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject obj in objs){
            positions.Add(obj.transform.position);
        }
        foreach(GameObject play in player){
            positions.Add(play.transform.position);
        }
        return positions;
    }

    public static List<Vector2> getWalls(){
        List<Vector2> positions = new List<Vector2>();
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Wall");
        foreach(GameObject obj in objs){
            // Debug.Log(obj.tag);
            // Debug.Log(obj.transform.position.x + ", " + obj.transform.position.y);
            positions.Add(obj.transform.position);
        }
        return positions;
    }

    public static List<Vector2> getRedBlocks(){
        List<Vector2> positions = new List<Vector2>();
        GameObject[] objs = GameObject.FindGameObjectsWithTag("RedBlock");
        foreach(GameObject obj in objs){
            positions.Add(obj.transform.position);
        }
        return positions;
    }

    public static List<Vector2> getGreenBlocks(){
        List<Vector2> positions = new List<Vector2>();
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GreenBlock");
        foreach(GameObject obj in objs){
            positions.Add(obj.transform.position);
        }
        return positions;
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
                GameObject.AddComponent<Block>();
                GameObject.GetComponent<Block>().setUp(true);
                if(this.tag.Equals("Player") || this.tag.Equals("Attached")){
                    GameObject.AddComponent<PlayerController>();
                    GameObject.gameObject.tag = ("Attached");
                }

                else if(this.tag.Equals("GreenBlock") || this.tag.Equals("RedBlock")){
                    GameObject.AddComponent<Block>();
                    GameObject.gameObject.tag = this.tag;
                }

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
                GameObject.AddComponent<Block>();
                GameObject.GetComponent<Block>().setLeft(true);
                if(this.tag.Equals("Player") || this.tag.Equals("Attached")){
                    GameObject.AddComponent<PlayerController>();
                    GameObject.gameObject.tag = ("Attached");
                }

                else if(this.tag.Equals("GreenBlock") || this.tag.Equals("RedBlock")){
                    GameObject.AddComponent<Block>();
                    GameObject.gameObject.tag = this.tag;
                }
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
                GameObject.AddComponent<Block>();
                GameObject.GetComponent<Block>().setDown(true);
                if(this.tag.Equals("Player") || this.tag.Equals("Attached")){
                    GameObject.AddComponent<PlayerController>();
                    GameObject.gameObject.tag = ("Attached");
                }

                else if(this.tag.Equals("GreenBlock") || this.tag.Equals("RedBlock")){
                    GameObject.AddComponent<Block>();
                    GameObject.gameObject.tag = this.tag;
                }

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
                GameObject.AddComponent<Block>();
                GameObject.GetComponent<Block>().setRight(true);
                if(this.tag.Equals("Player") || this.tag.Equals("Attached")){
                    GameObject.AddComponent<PlayerController>();
                    GameObject.gameObject.tag = ("Attached");
                }

                else if(this.tag.Equals("GreenBlock") || this.tag.Equals("RedBlock")){
                    GameObject.AddComponent<Block>();
                    GameObject.gameObject.tag = this.tag;
                }
            }
            else {
                Debug.Log("Texture Not Found");
            }
        }

        else{
            Debug.Log("Block could not be created" + dir + "of block at " + transform.position);
        }
    }

    public static bool canMove(char direction){
        for(int i = 0; i < player.Count; i++){
            Vector2 location = player[i];
            if(direction.Equals('l')){
                Debug.Log("Moving Left!");
                location.x -= 1;
            }
            if(direction.Equals('r')){
                Debug.Log("Moving Right!");
                location.x += 1;
            }
            if(direction.Equals('u')){
                Debug.Log("Moving Up!");
                location.y += 1;
            }
            if(direction.Equals('d')){
                Debug.Log("Moving Down");
                location.y -= 1;
            }
            for(int j = 0; j < walls.Count; j++){
                if(walls.Contains(location)){
                    Debug.Log("Cannot move");
                    return false;
                }
            }
        }
        Debug.Log("Successfully Moved!");
        return true;
    }
}
