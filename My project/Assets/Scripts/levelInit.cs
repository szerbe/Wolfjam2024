using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

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

    void createKey(String fileName){
        var scene = 
        var GameObject = new GameObject();
        var SpriteRenderer = GameObject.AddComponent<SpriteRenderer>();
        var playerTexture = Resources.Load<Texture2D>("Art/Tiles/blueTile.png");
        var redBlockTexture = Resources.Load<Texture2D>("Art/Tiles/redTile.png");
        var greenBlockTexture = Resources.Load<Texture2D>("Art/Tiles/greenTile.png");
        var wallBlockTexture = Resources.Load<Texture2D>("Art/Tiles/newWallBlock");
        Vector2 position;
        if(playerTexture == null){
            Debug.Log("Player texture failed to load");
        }
        if(redBlockTexture == null){
            Debug.Log("red texture failed to load");
        }
        if(greenBlockTexture == null){
            Debug.Log("green texture failed to load");
        }
        if(wallBlockTexture == null){
            Debug.Log("wall texture failed to load");
        }
        TextAsset textFile = Resources.Load<TextAsset>("Levels/" + fileName);
        String sc = textFile.text;
        int i = 0;
        int j = 0;
        for(int x = 0; i < scene.GetLength(0); x++){
            for(int y = 0; i < scene.GetLength(1); y++){
                switch(scene[x, y]){
                    case('E'):
                        break;
                    case('W'):
                        SpriteRenderer.sprite = Sprite.Create(wallBlockTexture, new Rect(0, 0, wallBlockTexture.width, wallBlockTexture.height), new Vector2(0.5f, 0.5f), 64);
                        position = GameObject.transform.position;
                        position.x = x;
                        position.y = y;
                        GameObject.transform.position = position;
                        GameObject.tag = "Wall";
                        break;
                    case('B'):
                        SpriteRenderer.sprite = Sprite.Create(playerTexture, new Rect(0, 0, playerTexture.width, playerTexture.height), new Vector2(0.5f, 0.5f), 64);
                        position = GameObject.transform.position;
                        position.x = x;
                        position.y = y;
                        GameObject.transform.position = position;
                        GameObject.AddComponent<PlayerController>();
                        GameObject.AddComponent<Block>();
                        GameObject.tag = "Player";
                        break;

                    case('R'):
                        SpriteRenderer.sprite = Sprite.Create(redBlockTexture, new Rect(0, 0, redBlockTexture.width, redBlockTexture.height), new Vector2(0.5f, 0.5f), 64);
                        position = GameObject.transform.position;
                        position.x = x;
                        position.y = y;
                        GameObject.transform.position = position;
                        GameObject.AddComponent<Block>();
                        GameObject.tag = "Wall";
                        break;

                    case('G'):
                        SpriteRenderer.sprite = Sprite.Create(greenBlockTexture, new Rect(0, 0, greenBlockTexture.width, greenBlockTexture.height), new Vector2(0.5f, 0.5f), 64);
                        position = GameObject.transform.position;
                        position.x = x;
                        position.y = y;
                        GameObject.transform.position = position;
                        GameObject.AddComponent<Block>();
                        GameObject.tag = "Wall";
                        break;
                }
            }
        }
    }

    int[] createScene(int levelNum){
        return new int[1];
    }
}
