using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;



public class Setup
{
//Block.getAttachedBlocks()
    private Vector2[] key;
    private char[,] scene;

    private Vector2 startPos;
    
    // //public static main(string[] args){
    // //
    // //}

     public Setup(String fileName){
        var playerTexture = Resources.Load<Texture2D>("Art/Tiles/blueTile.png");
        var redBlockTexture = Resources.Load<Texture2D>("Art/Tiles/redTile.png");
        var greenBlockTexture = Resources.Load<Texture2D>("Art/Tiles/greenTile.png");
        var wallBlockTexture = Resources.Load<Texture2D>("Art/Tiles/newWallBlock.png");
        TextAsset textFile = Resources.Load<TextAsset>("Levels/" + fileName);
        String sc = textFile.text;
        int i = 0;
        int j = 0;
        scene = new char[sc[0], sc[2]];
        Debug.Log(sc);
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
