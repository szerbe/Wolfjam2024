using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using Unity.VisualScripting;



public class Setup {
//Block.getAttachedBlocks()
    private Vector2[] key;
    private char[,] scene;

    private Vector2 startPos;
    
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
                        Vector2 position = GameObject.transform.position;
                        position.x = x;
                        position.y = y;
                        GameObject.transform.position = position;
                        GameObject.AddComponent<Block>();
                        GameObject.tag = "Wall";
                        break;

                    case('G'):
                        SpriteRenderer.sprite = Sprite.Create(greenBlockTexture, new Rect(0, 0, greenBlockTexture.width, greenBlockTexture.height), new Vector2(0.5f, 0.5f), 64);
                        Vector2 position = GameObject.transform.position;
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
}
