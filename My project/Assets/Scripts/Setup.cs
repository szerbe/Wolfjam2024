using System;
using System.Runtime.CompilerServices;
using UnityEngine;



public class Block : MonoBehaviour
{
    
private char[30][30];

    public Block(bool r, bool l, bool a, bool b){
        right = r;
        left = l;
        above = a;
        below = b;
    }
    public Boolean isRight(){
        return right;
    }

    public Boolean isLeft(){
        return left;
    }

    public Boolean isAbove(){
        return above;
    }

    public Boolean isBelow(){
        return below;
    }

}
