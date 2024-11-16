using UnityEngine;

public class Character : Block
{
    private int[] near = [0,0,0,0];
    //0 = no character block, 1 = nearby character block
    //Right, Down, Left, Up
    public static char color(){
        return 'c';
    }

    public Block(char c){
        color = c;
    }

    public void change(int direction, int change){
        near[direction] = change;
    }

    public int[] near(){
        return near;
    }
}
