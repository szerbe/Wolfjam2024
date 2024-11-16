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

    public void change(char direction, int change){
        int d = 0; //right, direction = 'r'
        if(char.Equals('d')){
            d = 1;
        }
        if(char.Equals('l')){
            d = 2;
        }
        if(char.Equals('u')){
            d = 3;
        }
        near[d] = change;
    }

    public int[] near(){
        return near;
    }
}
