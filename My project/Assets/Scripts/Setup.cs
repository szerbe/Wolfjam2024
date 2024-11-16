using System;
using System.Runtime.CompilerServices;
using UnityEngine;



public class Setup
{
    private char[30][30] scene;
    private int[10][2] key;
    private List<int[]> character;
    private int size = 1; //character size
    
    //public static main(string[] args){
    //
    //}

    public Console(char[][] level, int[][] key, int[]character){
        scene = level;
        key = key;
        character.Add(character);
    }
    

    public void rotateL(){

    }

    public void rotateR(){
        
    }

    public void move(){

    }

    public bool isKey(){
        if(size == key.getLength(0)) && checkKey()){
            return true;
        }
        return false;
    }

    public bool checkKey(){
        for(int i = 0; i < key.GetLength(0)){
            for(int j = 0; j < key.GetLength(1)){
                if(scene[i][j].color().Equals('y')){
                    return true;
                }
            }
        }
        return false;
    }

    public char[][] getScene(){
        return scene;
    }
}
