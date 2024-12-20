using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using UnityEngine.Tilemaps;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine.UIElements;
using System.Linq;


public class levelInit : MonoBehaviour
{
    
    private char[,] scene;
    private List<Vector2> key;
    private Vector2 position = Vector2.zero;


    public levelInit(int levelNum){
        UnityEngine.SceneManagement.Scene newScene = SceneManager.CreateScene("level" + levelNum);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.SetActiveScene(newScene);
        key = new List<Vector2>();
        GameObject gameObject = new GameObject();
        gameObject.AddComponent<levelInit>();
        gameObject.AddComponent<Camera>();
        gameObject.GetComponent<Camera>().tag = "MainCamera";
        gameObject.GetComponent<Camera>().orthographic = true;
        createScene("level" + levelNum, gameObject);
        PlayerController.setRotationPoint();
    }

    void Start(){
        //Create scene
        // Setup setup = new Setup(scene, key, position);
    }

    void Update(){
        Block.UpdateTags();
        if(checkKey()){
            Debug.Log("Congrats");
            levelInit.loadLevelSelect();
        }
    }

    public static void loadLevelSelect(){
        SceneManager.LoadScene("levelSelect");
        int count = SceneManager.sceneCount;
        for(int i = 0; i < count; i++){
            if(!SceneManager.GetSceneAt(i).Equals(SceneManager.GetActiveScene())){
                SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(i));
            }
        }
    }
    void createScene(String fileName, GameObject obj){
        var scene = new Setup(fileName).getScene();
        GameObject gameObject;
        SpriteRenderer spriteRenderer;
        var grid = new GameObject("Grid").AddComponent<Grid>();
        var tilemap = new GameObject("Tilemap").AddComponent<Tilemap>();
        var rend = grid.AddComponent<SpriteRenderer>();
        tilemap.transform.SetParent(grid.gameObject.transform);
        var playerTexture = Resources.Load<Texture2D>("Art/Tiles/blueTile.png");
        var redBlockTexture = Resources.Load<Texture2D>("Art/Tiles/redTile.png");
        var greenBlockTexture = Resources.Load<Texture2D>("Art/Tiles/greenTile.png");
        var wallBlockTexture = Resources.Load<Texture2D>("Art/Tiles/newWallBlock");
        var yellowBlockTexture = Resources.Load<Texture2D>("Art/Tiles/tile2.png");

        if(fileName.Equals("level0.txt")){
            var blueIntro = Resources.Load<Texture2D>("Art/Text/blueIntro.png");
            var greenIntro = Resources.Load<Texture2D>("Art/Text/greenIntro.png");
            var redIntro = Resources.Load<Texture2D>("Art/Text/redIntro.png");
            var yellowIntro = Resources.Load<Texture2D>("Art/Text/yellowIntro");
            var controlsText = Resources.Load<Texture2D>("Art/Text/controlsText.png");
            Vector2 position0;

            gameObject = new GameObject();
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = Sprite.Create(blueIntro, new Rect(0, 0, blueIntro.width, blueIntro.height), new Vector2(0.5f, 0.5f), 64);
            position0 = gameObject.transform.position;
            position0.x = 0;
            position0.y = 0;
            gameObject.transform.position = position0;
        }
        var tile = Instantiate<Tile>(ScriptableObject.CreateInstance<Tile>());
        tile.sprite = Sprite.Create(Resources.Load<Texture2D>("Art/Tiles/tile1.png"), new Rect(0, 0, wallBlockTexture.width, wallBlockTexture.height), new Vector2(0.5f, 0.5f), 64);
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
        if(tile.sprite == null){
            Debug.Log("Tile failed to load");
        }
        TextAsset textFile = Resources.Load<TextAsset>("Levels/" + fileName);
        String sc = textFile.text;
        obj.GetComponent<Camera>().orthographicSize = scene.GetLength(0)/7;
        obj.GetComponent<Camera>().transform.position = new Vector3(scene.GetLength(0)/4 - 1, -scene.GetLength(1)/4 + 1, -5);
        for(int x = scene.GetLength(0) - 1; x >= 0; x--){
            for(int y = scene.GetLength(1) - 1; y >= 0; y--){
                tilemap.SetTile(new Vector3Int(x, -y, 0), tile);
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
                        // Debug.Log("Creating wall at" + x + ", " + y);
                        gameObject.transform.position = position;
                        gameObject.tag = "Wall";
                        break;
                    case('C'):
                        gameObject = new GameObject();
                        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
                        Sprite sprite = Sprite.Create(playerTexture, new Rect(0, 0, playerTexture.width, playerTexture.height), new Vector2(0.5f, 0.5f), 64);
                        spriteRenderer.sprite = sprite;
                        spriteRenderer.sortingLayerName = "Top";
                        Vector3 pos = gameObject.transform.position;
                        pos.x = x;
                        pos.y = -y;
                        // Debug.Log("Creating player at" + x + ", " + y);
                        gameObject.transform.position = pos;
                        gameObject.AddComponent<PlayerController>();
                        gameObject.AddComponent<Block>();
                        gameObject.tag = "Player";
                        break;

                    case('R'):
                        gameObject = new GameObject();
                        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
                        spriteRenderer.sprite = Sprite.Create(redBlockTexture, new Rect(0, 0, redBlockTexture.width, redBlockTexture.height), new Vector2(0.5f, 0.5f), 64);
                        position.x = x;
                        position.y = -y;
                        // Debug.Log("Creating red at" + x + ", " + y);
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
                        // Debug.Log("Creating green at" + x + ", " + y);
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
                        // Debug.Log("Creating yellow at" + x + ", " + y);
                        gameObject.transform.position = position;
                        gameObject.tag = "YellowBlock";
                        key.Add(new Vector2(x, -y));
                        break;
                }
            }
        }

    }

    int[] createScene(int levelNum){
        return new int[1];
    }
    
    public static bool checkKey(){
        // if(key.Count != Block.getAttachedBlocks().Count) return false;
        // for(int i = 0; i < key.Count; i++){
        //     foreach(Vector2 v in Block.getAttachedBlocks()){
        //         if(key[i].Equals(v)){
        //             Debug.Log("Counting!");
        //             matches++;
        //         }
        //     }
        // }
        int matches = 0;
        List<GameObject> playerObjects = new List<GameObject>();
        // Debug.Log("Called");
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Attached")){
            playerObjects.Add(g);
        }
        playerObjects.Add(GameObject.FindGameObjectWithTag("Player"));
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("YellowBlock");
        if(gameObjects.Count() != playerObjects.Count()){
            // Debug.Log("False");
            return false;
        }
        foreach(GameObject p in playerObjects){
            foreach(GameObject g in gameObjects){
                if (p.transform.position.Equals(g.transform.position)){
                    // Debug.Log("Count");
                    matches++;
                }
            }
        }
        // Debug.Log("Through");
        return matches == gameObjects.Count();
        //hello
    }
}
