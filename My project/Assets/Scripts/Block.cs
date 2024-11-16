using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Block : MonoBehaviour
{
    private char color;

    public Block(char c){
        //'r' = Red = subtract
        //'g' = Green = merge
        //'b' = black = obstacle (cannot overlap)
        //'c' = blue = character (subclass)
        //'y' = key = win condition
        color = c;
    }
    
    public static color(){
        return color;
    }

}
