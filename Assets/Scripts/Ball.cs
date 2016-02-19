using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    Rigidbody2D rigidBodyMe; 
    private Vector3 PaddleToBallVector;
    public bool hasStarted = false;
    private AudioSource audio;
    
        
	// Use this for initialization
	void Start () {
       audio = GetComponent<AudioSource>();
	   paddle = GameObject.FindObjectOfType<Paddle>();
       PaddleToBallVector = this.transform.position - paddle.transform.position;
       rigidBodyMe = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted){
            // Lock the ball relative to the paddle
            this.transform.position = paddle.transform.position + PaddleToBallVector;
            // Wait for a mouse press to launch 
            if (Input.GetMouseButton(0)){
                hasStarted = true;
                rigidBodyMe.velocity = new Vector2(2f, 10f);
            }
       }
	}    
    void OnCollisionEnter2D(Collision2D collision){
        Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        if (hasStarted){audio.Play();}
        rigidBodyMe.velocity += tweak;
    }
}
