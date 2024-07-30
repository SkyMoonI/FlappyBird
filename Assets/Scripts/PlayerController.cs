using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	AudioManager audioManager;
	private float jumpForce = 8f;
	private float customGravityScale = 3f;

	private Rigidbody2D rb;

	void Awake()
	{
		audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
	}
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.gravityScale = customGravityScale;
	}
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Obstacle")
		{
			// Get the current highest score
			Score.GetHighScore();
			// Show the high score text
			Score.HideUnHideTextsStatic();
			Time.timeScale = 0f;
			audioManager.Play(audioManager.death);
		}

	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Score")
		{
			audioManager.Play(audioManager.scoreUp);
			Score.AddScore();
		}
	}
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			audioManager.Play(audioManager.jump);
			rb.velocity = Vector2.zero; // reset velocity to 0 before jumping
			rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // jump 
		}
	}
}
