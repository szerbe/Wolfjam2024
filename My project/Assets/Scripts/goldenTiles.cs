using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class goldenTiles : TileBase
{
    private GameObject playerObj = null;

    void Start(){
        if(playerObj == null){
            playerObj = GameObject.FindGameObjectWithTag("Player");
        }
    }
    void Update(){
        if(playerObj.transform.position.Equals(Vector2.zero)){

        }
            
            SceneManager.LoadScene("level1");
    }
}
