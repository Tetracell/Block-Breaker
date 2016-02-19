using UnityEngine;
using System.Collections;

public class music_player : MonoBehaviour {

	static music_player instance = null;
    
    void Awake(){
        if (instance != null){
            Destroy(gameObject);
            print("Duplicate music player self-destructing.");
        } else {
            instance = this; // this = self.instance, as done in python
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
    
    // Use this for initialization
	// void Start () {} ***Empty as of right now***
    	
	// Update is called once per frame
	void Update () {
	
	}
}
