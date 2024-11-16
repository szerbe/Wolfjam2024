using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class levelInit : MonoBehaviour
{
    
    private char[,] scene;
    private int[,] key;
    private Vector2 position = Vector2.zero;

    public levelInit(int levelNum){
        createScene(levelNum);
        createKey(levelNum);
    }

    void Start(){
        //Create scene
        //Create key
        SceneManager.CreateScene("level");
        // Setup setup = new Setup(scene, key, position);
    }

    int[] createKey(int levelNum){
        return new int[1];
    }

    int[] createScene(int levelNum){
        return new int[1];
    }
}
