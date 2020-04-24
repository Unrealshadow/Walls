using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    // Variables for storing the bounce and death animation
    public GameObject wallBounceEffectGameObject;
    public GameObject deathEffectObj;

    // GUI elements for storing the current score and final score
    public Text scoreText;
    public Text finalScoreText;
    public Text highScoreText;

    // Rigidbody so that the player acts based on real world physics(gravity,force,velocity etc)
    private Rigidbody2D rb;

    // Variables for storing the velocity values
    private int jumpX = 8;
    private int jumpY = 14;

    // Variables for storing store, keeping track of whether the player is playing or has finished playing
    private int score = 0;
    private bool isDead = false;
    public bool isGameStarted = false;

	// Use this for initialization
	void Start () {

        highScoreText.text ="High Score\n" + PlayerPrefs.GetInt("HighScore",0); 
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        // On Mouse Down or Screen tap apply velcity on the rigid body(player)
        // If Player is moving right then velocity along x-axis is positive
        // On Mouse Down or Screen tap again apply velocity in the direction in which player is moving
        if (Input.GetMouseButtonDown(0) && isGameStarted == true) {
            if (rb.velocity.x > 0 ) {
                rb.velocity = new Vector2(jumpX, jumpY);
            }
            else
            {
                rb.velocity = new Vector2(-jumpX, jumpY);
            }   
        }
	}

    // Checking whether the player has collided with any object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If collision is with wall then instantiate(create) a wall bounce effect
        // Destroy it after 0.35 seconds
        if (collision.gameObject.tag == "Wall")
        {
           GameObject effectObj =  Instantiate(wallBounceEffectGameObject,collision.contacts[0].point,Quaternion.identity);
           Destroy(effectObj, 0.35f);
        }
        // If Collision is left or right wall then add 1 to the total score
        if(collision.gameObject.name == "Left" || collision.gameObject.name == "Right")
        {
            FindObjectOfType<ColourChange>().ChangeColor();
            score++;
            scoreText.text = score + "";
            finalScoreText.text = "Score\n" + score; 
        }
        // If player collides with an enemy(triangle) then destroy the player
        // Stop its motion and hide it(setactive to false)
        if (collision.gameObject.tag == "Triangle" && isDead == false)
        {
            isDead = true;
            GameObject effectObj = Instantiate(deathEffectObj, collision.contacts[0].point, Quaternion.identity);
            Destroy(effectObj, 0.8f);

            rb.velocity = new Vector2(0, 0);
            rb.isKinematic = true;
            gameObject.SetActive(false);
            isGameStarted = false;

            //Setting the highscore
            if (score > PlayerPrefs.GetInt("HighScore", 0)) {
                PlayerPrefs.SetInt("HighScore", score);
                highScoreText.text = "High Score\n" + score;
            }

            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public int GetScore()
    {
        return score;
    }
}
