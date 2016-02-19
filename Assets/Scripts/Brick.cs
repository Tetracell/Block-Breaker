using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
    
    public AudioClip crack;
    public Sprite[] hitSprites;
    public GameObject smoke;
    public static int brickCount = 0;
    private bool isBreakable;    
    private int timesHit;
    private LevelManager levelManager;
    private int maxHits;
  
    
	// Use this for initialization
	void Start () {
       isBreakable = (this.tag == "Breakable");
       if (isBreakable){
           brickCount++;
           print(brickCount);
       }
       timesHit = 0;
       levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {	   
	}
    
    /* Changed this from Enter2D to Exit2D based on //recommendation from comments.
     Why is this, though? // W/O this, ball simply passes through blocks instead // 
     of bouncing off of them. */
     
    void OnCollisionExit2D(Collision2D collision){     
              //AudioSource.PlayClipAtPoint(crack, transform.position);
              if (isBreakable){
                  HandleHits();
              }                                       
        }                                                  
    
    void HandleHits () {
        timesHit ++;   
        maxHits = hitSprites.Length + 1;               
        if (timesHit >= maxHits){
            brickCount--;
            levelManager.BrickDestroyed();
            PuffSmoke();            
            Destroy(gameObject);
            print(brickCount);            
        } else {
            LoadSprites();
        }          
    }
    
    void PuffSmoke(){
        GameObject smokePuff = Instantiate (smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
        smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }
    void LoadSprites() {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex]){
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } 
        
    }
    
    void simulateWin(){
        levelManager.LoadNextLevel();
    }
}
