using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 0f)
		{
			RestartTheGame();
			Score.ResetScore();
			// Hide the high score text
			Score.HideUnHideTextsStatic();
		}

	}
	public void RestartTheGame()
	{
		// Get the current scene index
		int currentLevel = SceneManager.GetActiveScene().buildIndex;
		// Reload the current scene
		SceneManager.LoadScene(currentLevel);
		Time.timeScale = 1f;
	}
}
