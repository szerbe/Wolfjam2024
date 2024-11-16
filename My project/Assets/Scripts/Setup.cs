using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;



public class Setup
{
    private char[,] scene;
    private int[,] key;
    private ArrayList character;
    private int size = 1; //character size
    
    //public static main(string[] args){
    //
    //}

    public Setup(char[,] level, int[,] key, int[]character){
        scene = level;
        key = key;
        character.Add(character);
    }
    

    public void rotateR(){
        for(int i = 0; i < character.Capacity()){
            int[] c = scene[character[i][0],character[i][1]].near();
            for(int j = 0; j < 3; j++){
                scene[character[i][0],character[i][1]].change(j+1,1);
            }
            if(c[4]==1){
                scene[character[i][0],character[i][1]].change(0,1);
            }
        }
    }

    public void rotateL(){
        for(int i = 0; i < character.Capacity()){
            int[] c = scene[character[i][0],character[i][1]].near();
            for(int j = 4; j > 0; j++){
                scene[character[i][0],character[i][1]].change(j-1,1);
            }
            if(c[0]==1){
                scene[character[i][0],character[i][1]].change(4,1);
            }
        }
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
