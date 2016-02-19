using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {
    
    private LevelManager levelManager;
    void OnCollisionEnter2D(Collision2D collision){
        print ("Collision");
        levelManager.LoadLevel("Lose Screen");
    }
    
    void Start(){
        levelManager = GameObject.FindObjectOfType<LevelManager>();  
    }
}
