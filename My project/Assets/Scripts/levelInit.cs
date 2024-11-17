using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using UnityEngine.Tilemaps;

public class levelInit : MonoBehaviour
{
    
    private char[,] scene;
    private int[,] key;
    private Vector2 position = Vector2.zero;


    public levelInit(int levelNum){
        UnityEngine.SceneManagement.Scene newScene = SceneManager.CreateScene("level" + levelNum);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.SetActiveScene(newScene);
        GameObject gameObject = new GameObject();
        gameObject.AddComponent<levelInit>();
        gameObject.AddComponent<Camera>();
        gameObject.GetComponent<Camera>().tag = "MainCamera";
        gameObject.GetComponent<Camera>().orthographic = true;
        createScene("level" + levelNum, gameObject);
    }

    void Start(){
        //Create scene
        //Create key
        // Setup setup = new Setup(scene, key, position);
    }

    void Update(){
        Block.UpdateTags();
    }

    void createScene(String fileName, GameObject obj){
        var scene = new Setup(fileName).getScene();
        GameObject gameObject;
        SpriteRenderer spriteRenderer;
        var playerTexture = Resources.Load<Texture2D>("Art/Tiles/blueTile.png");
        var redBlockTexture = Resources.Load<Texture2D>("Art/Tiles/redTile.png");
        var greenBlockTexture = Resources.Load<Texture2D>("Art/Tiles/greenTile.png");
        var wallBlockTexture = Resources.Load<Texture2D>("Art/Tiles/newWallBlock");
        var yellowBlockTexture = Resources.Load<Texture2D>("Art/Tiles/tile2.png");
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
        obj.GetComponent<Camera>().orthographicSize = scene.GetLength(0)/4;
        obj.GetComponent<Camera>().transform.position = new Vector2(scene.GetLength(0)/4 - 1, -scene.GetLength(1)/4 + 1);
        for(int x = scene.GetLength(0) - 1; x >= 0; x--){
            for(int y = scene.GetLength(1) - 1; y >= 0; y--){
                switch(scene[x, y]){
                    case('E'):
                        break;
                    case('B'):
                        gameObject = new GameObject();
                        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
                        spriteRenderer.sprite = Sprite.Create(wallBlockTexture, new Rect(0, 0, wallBlockTexture.width, wallBlockTexture.height), new Vector2(0.5f, 0.5f), 64);
                        position = gameObject.transform.position;
                        position.x = x;
                        position.y = -y;
                        Debug.Log("Creating wall at" + x + ", " + y);
                        gameObject.transform.position = position;
                        gameObject.tag = "Wall";
                        break;
                    case('C'):
                        gameObject = new GameObject();
                        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
                        spriteRenderer.sprite = Sprite.Create(playerTexture, new Rect(0, 0, playerTexture.width, playerTexture.height), new Vector2(0.5f, 0.5f), 64);
                        position = gameObject.transform.position;
                        position.x = x;
                        position.y = -y;
                        Debug.Log("Creating player at" + x + ", " + y);
                        gameObject.transform.position = position;
                        gameObject.AddComponent<PlayerController>();
                        gameObject.AddComponent<Block>();
                        gameObject.tag = "Player";
                        break;

                    case('R'):
                        gameObject = new GameObject();
                        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
                        spriteRenderer.sprite = Sprite.Create(redBlockTexture, new Rect(0, 0, redBlockTexture.width, redBlockTexture.height), new Vector2(0.5f, 0.5f), 64);
                        position = gameObject.transform.position;
                        position.x = x;
                        position.y = -y;
                        Debug.Log("Creating red at" + x + ", " + y);
                        gameObject.transform.position = position;
                        gameObject.AddComponent<Block>();
                        gameObject.tag = "RedBlock";
                        break;

                    case('G'):
                        gameObject = new GameObject();
                        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
                        spriteRenderer.sprite = Sprite.Create(greenBlockTexture, new Rect(0, 0, greenBlockTexture.width, greenBlockTexture.height), new Vector2(0.5f, 0.5f), 64);
                        position = gameObject.transform.position;
                        position.x = x;
                        position.y = -y;
                        Debug.Log("Creating green at" + x + ", " + y);
                        gameObject.transform.position = position;
                        gameObject.AddComponent<Block>();
                        gameObject.tag = "GreenBlock";
                        break;
                    case('Y'):
                        gameObject = new GameObject();
                        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
                        spriteRenderer.sprite = Sprite.Create(yellowBlockTexture, new Rect(0, 0, yellowBlockTexture.width, yellowBlockTexture.height), new Vector2(0.5f, 0.5f), 64);
                        position = gameObject.transform.position;
                        position.x = x;
                        position.y = -y;
                        Debug.Log("Creating yellow at" + x + ", " + y);
                        gameObject.transform.position = position;
                        gameObject.tag = "YellowBlock";
                        break;
                }
            }
        }
    }

    int[] createScene(int levelNum){
        return new int[1];
    }
}
