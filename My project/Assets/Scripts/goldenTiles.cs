using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class goldenTiles : MonoBehaviour
{
    private GameObject playerObj = null;

    public goldenTiles(){
        
    }

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
