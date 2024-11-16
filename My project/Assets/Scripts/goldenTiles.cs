using UnityEngine;
using UnityEngine.SceneManagement;

public class goldenTiles : MonoBehaviour
{
    private GameObject playerObj = null;

    void Start(){
        if(playerObj == null){
            playerObj = GameObject.FindGameObjectWithTag("Player");
        }
    }
    void Update(){
        if(playerObj.transform.position == transform.position){
            SceneManager.LoadScene("level1");
        }
    }
}
