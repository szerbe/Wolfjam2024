using System;
using System.Runtime.CompilerServices;
using UnityEngine;



public class Block : MonoBehaviour
{
    
private bool right;
private bool left;
private bool above;
private bool below;

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
