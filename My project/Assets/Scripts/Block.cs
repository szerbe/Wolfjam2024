using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Block : MonoBehaviour
{
    private char color;

    public Block(char c){
        //'r' = Red = subtract
        //'g' = Green = merge
        //'b' = Black = obstacle (cannot overlap)
        //'c' = Blue = character (subclass)
        //'y' = key = win condition
        //'e' = Empty = no tile
        color = c;
    }
    
    public static char color(){
        return color;
    }

}
