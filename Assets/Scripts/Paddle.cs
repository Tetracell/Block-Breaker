using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    private Ball ball;
	// Use this for initialization
	void Start () {	
        ball = GameObject.FindObjectOfType<Ball>();
        print(ball);
	}
    
    void autoPlayer(){
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x-0.5f, 0f, 15f);
        this.transform.position = paddlePos;
    }
	
	// Update is called once per frame
	void Update () {
        if (!autoPlay){
            moveWithMouse();
        } else {
            autoPlayer();
        }
        
	}
    
    void moveWithMouse(){
        Vector3 paddlePos = new Vector3(this.transform.position.x, this.transform.position.y, 0f);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width*16;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0f, 15f);
        this.transform.position = paddlePos;
    }
}
