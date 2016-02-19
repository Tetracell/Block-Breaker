using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

   
	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
    
    public void LoadNextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void LoadLevel(string name) {
        SceneManager.LoadScene(name);
        Brick.brickCount = 0;
        
    }
    public void BrickDestroyed(){
        if (Brick.brickCount <= 0){
            LoadNextLevel();
        }
    }
}
