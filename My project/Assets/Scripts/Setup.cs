using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEditor.SearchService;


public class Setup {
//Block.getAttachedBlocks()
    private Vector2[] key;
    private char[,] scene;

    private Vector2 startPos;

    private List<int[]> character;

    private int blockWidth = 1;
    private int blockHeight = 1;
    
    // //public static main(string[] args){
    // //
    // //}

     public Setup(String fileName){
        var GameObject = new GameObject();
        var SpriteRenderer = GameObject.AddComponent<SpriteRenderer>();
        var playerTexture = Resources.Load<Texture2D>("Art/Tiles/blueTile.png");
        var redBlockTexture = Resources.Load<Texture2D>("Art/Tiles/redTile.png");
        var greenBlockTexture = Resources.Load<Texture2D>("Art/Tiles/greenTile.png");
        var wallBlockTexture = Resources.Load<Texture2D>("Art/Tiles/newWallBlock");
        Vector2 position;
        if(playerTexture == null){
            Debug.Log("Player texture failed to load");
        }
        if(redBlockTexture == null){
            Debug.Log("red texture failed to load");
        }
        if(greenBlockTexture == null){
            Debug.Log("green texture failed to load");
        }
        if(wallBlockTexture == null){
            Debug.Log("wall texture failed to load");
        }
        TextAsset textFile = Resources.Load<TextAsset>("Levels/" + fileName);
        String sc = textFile.text;
        int i = 0;
        int j = 0;
        scene = new char[Convert.ToInt32(sc[0]), Convert.ToInt32(sc[2])];
        Debug.Log(sc);
        sc = sc.Substring(3);
        foreach(char c in sc){
            if(c.Equals(':')){
                j++;
                Debug.Log(c);
            }
            else if(!c.Equals(' ')){
                scene[i, j] = c;
                i++;
                Debug.Log(c);
            }
        }
        
        for(int x = 0; i < scene.GetLength(0); x++){
            for(int y = 0; i < scene.GetLength(1); y++){
                switch(scene[x, y]){
                    case('E'):
                        break;
                    case('W'):
                        SpriteRenderer.sprite = Sprite.Create(wallBlockTexture, new Rect(0, 0, wallBlockTexture.width, wallBlockTexture.height), new Vector2(0.5f, 0.5f), 64);
                        position = GameObject.transform.position;
                        position.x = x;
                        position.y = y;
                        GameObject.transform.position = position;
                        GameObject.tag = "Wall";
                        break;
                    case('B'):
                        SpriteRenderer.sprite = Sprite.Create(playerTexture, new Rect(0, 0, playerTexture.width, playerTexture.height), new Vector2(0.5f, 0.5f), 64);
                        position = GameObject.transform.position;
                        position.x = x;
                        position.y = y;
                        GameObject.transform.position = position;
                        GameObject.AddComponent<PlayerController>();
                        GameObject.AddComponent<Block>();
                        GameObject.tag = "Player";
                        break;

                    case('R'):
                        SpriteRenderer.sprite = Sprite.Create(redBlockTexture, new Rect(0, 0, redBlockTexture.width, redBlockTexture.height), new Vector2(0.5f, 0.5f), 64);
                        position = GameObject.transform.position;
                        position.x = x;
                        position.y = y;
                        GameObject.transform.position = position;
                        GameObject.AddComponent<Block>();
                        GameObject.tag = "Wall";
                        break;

                    case('G'):
                        SpriteRenderer.sprite = Sprite.Create(greenBlockTexture, new Rect(0, 0, greenBlockTexture.width, greenBlockTexture.height), new Vector2(0.5f, 0.5f), 64);
                        position = GameObject.transform.position;
                        position.x = x;
                        position.y = y;
                        GameObject.transform.position = position;
                        GameObject.AddComponent<Block>();
                        GameObject.tag = "Wall";
                        break;
                }
            }
        }
        
    }

    public void build(){
        for (int i = 0; i < scene.GetLength(0); i++) {
            for (int j = 0; j < scene.GetLength(1); j++) {
                GameObject temp = Instantiate(Block(scene[i,j]), new Vector3(j * blockWidth, i * blockHeight, 0), Quaternion.identity) as GameObject;
                //format: Instiantiate(GameObject, Vector, Quaternion.identity)
            }
        }
    }
    public static bool canMove(char direction){
        List<int[]> player = scene;
        for(int i = 0; i < player.Count; i++){
            int[] location = player[i];
            if(direction.Equals('l')){
                Debug.Log("Moving Left!");
                location[0] -= 1;
            }
            if(direction.Equals('r')){
                Debug.Log("Moving Right!");
                location[0] += 1;
            }
            if(direction.Equals('u')){
                Debug.Log("Moving Up!");
                location[1] += 1;
            }
            if(direction.Equals('d')){
                Debug.Log("Moving Down");
                location[1] -= 1;
            }
            char color = scene[location[0],location[1]];
            if(color.Equals('B')){
                return false;
            }
            if(color.Equals('G')){
                player[location[0],location[1]] = new Block('C');
            }
            if(color.Equals('R')){
                player[location[0],location[1]] = new Block('B');
            }
        }
        Debug.Log("Successfully Moved!");
        return true;
    }

    public static bool canRotate(char direction){
        int cosX = 0;
        int sinX = 1;
        if(direction.Equals('r')){
            sinX = -1;
        }
        //Debug.Log(cosX + ", " + sinX);
        Vector2[] matrix = {new Vector2(cosX, -sinX), new Vector2(sinX, cosX)};

        List<int[]> player = scene;
        for(int i = 0; i < player.Count; i++){
            int[] location = player[i];
            location = new Vector2((float)Math.Round(matrix[0].x*player[i].x + matrix[0].y*player[i].y), (float)Math.Round(matrix[1].x*player[i].x + matrix[1].y*player[i].y));
            Debug.Log("Rotating: "+location.x + ", " + location.y);
            if(scene[location[0],location[1]].Equals('B')){
                return false;
            }
        }
        return true;
    }
    

    public bool checkKey(){
        int matches = 0;
        if(key.Length != Block.getAttachedBlocks().Count) return false;
        for(int i = 0; i < key.Count(); i++){
            if(key[i].Equals((Block.getAttachedBlocks()).ElementAt(i))){
                matches++;
            }
        }
        return matches == key.Length;
        //hello
    }
  

    // public char[][] getScene(){
    //     return scene;
    // }
}