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

    private static int blockWidth = 1;
    private static int blockHeight = 1;
    
    // //public static main(string[] args){
    // //
    // //}

     public Setup(String fileName){
        TextAsset textFile = Resources.Load<TextAsset>("Levels/" + fileName);
        String sc = textFile.text;
        int i = 0;
        int j = 0;
        scene = new char[Convert.ToInt32(sc[0]), Convert.ToInt32(sc[2])];
        Debug.Log(sc);
        sc = sc.Substring(sc.IndexOf('*') + 1);
        Debug.Log(sc);
        foreach(char c in sc){
            if(c.Equals(':')){
                j++;
                i = 0;
                Debug.Log(c);
            }
            else if(!c.Equals(' ')){
                scene[i, j] = c;
                i++;
                Debug.Log(c);
            }
        }
        
        // for(i = 0; i < scene.GetLength(0); i++){
        //     for(j = 0; j < scene.GetLength(1); j++){
        //         if(scene[i,j].Equals('C')){
        //             character.Add(new int[]{i,j});
        //             i = scene.GetLength(0);
        //             j = scene.GetLength(1);
        //         }
        //     }  
        // }
    }

    public char[,] getScene(){
        return scene;
    }

    // public void build(){
    //     for (int i = 0; i < scene.GetLength(0); i++) {
    //         for (int j = 0; j < scene.GetLength(1); j++) {
    //             GameObject temp = Instantiate(Block(scene[i,j]), new Vector3(j * blockWidth, i * blockHeight, 0), Quaternion.identity) as GameObject;
    //             //format: Instiantiate(GameObject, Vector, Quaternion.identity)
    //         }
    //     }
    // }
    
    public bool canMove(char direction){
        char[,] player = scene;
        for(int i = 0; i < character.Count; i++){
            int[] location = character[i];
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
            if(color.Equals('R')){
                player[location[0],location[1]] = 'B';
                player[character[i][0], character[i][1]] = 'E';
            }
            if(color.Equals('G')){
                player[location[0],location[1]] = 'C';
            }
            if(color.Equals('B')||color.Equals('R')||color.Equals('G')){
                return false;
            }
        }
        scene = player;
        Debug.Log("Successfully Moved!");
        return true;
    }


    public bool canRotate(char direction){
        int cosX = 0;
        int sinX = 1;
        if(direction.Equals('r')){
            sinX = -1;
        }
        //Debug.Log(cosX + ", " + sinX);
        int[,] matrix = {{cosX, -sinX}, {sinX, cosX}};

        char[,] player = scene;
        for(int i = 0; i < character.Count; i++){
            int[] location = {matrix[0,0]*character[i][0]*blockWidth + matrix[0,1]*character[i][1]*blockHeight, matrix[1,0]*character[i][0]*blockWidth + matrix[1,1]*character[i][1]*blockHeight};
            Debug.Log("Rotating: "+location[0] + ", " + location[1]);
            if(scene[location[0],location[1]].Equals('B')){
                return false;
            }
        }
        return true;
    }


    // public bool checkKey(){
    //     int matches = 0;
    //     if(key.Length != Block.getAttachedBlocks().Count) return false;
    //     for(int i = 0; i < key.Count(); i++){
    //         if(key[i].Equals((Block.getAttachedBlocks()).ElementAt(i))){
    //             matches++;
    //         }
    //     }
    //     return matches == key.Length;
    //     //hello
    // }

    public bool isKey(){
        if(character.Count == key.GetLength(0) && checkKey()){
            return true;
        }
        return false;
    }
    public bool checkKey(){
        for(int i = 0; i < key.GetLength(0); i++){
            for(int j = 0; j < key.GetLength(1); j++){
                if(scene[i,j].Equals('c')){
                    return true;
                }
            }
        }
        return false;
    }
    // public char[][] getScene(){
    //     return scene;
    // }
}