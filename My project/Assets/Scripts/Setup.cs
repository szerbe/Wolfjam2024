using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;



public class Setup
{
//Block.getAttachedBlocks()
    private Vector2[] key;
    private char[][] scene;
    // private ArrayList character;
    // private int size = 1; //character size
    
    // //public static main(string[] args){
    // //
    // //}

     public Setup(char[][] level, Vector2[] key, int[]character){
         scene = level;
         key = key;
         character.Add(character);
    }
    

    public bool checkKey(){
        int matches = 0;
        if(key.Length() != Block.getAttachedBlocks().Length()) return false;
        for(int i = 0; i < key.Length(); i++){
            if(key[i].Equals((Block.getAttachedBlocks)[i])){
                matches++;
            }
        }
        return matches == key.Length();
        //hello
    }
  

    // public char[][] getScene(){
    //     return scene;
    // }
}
