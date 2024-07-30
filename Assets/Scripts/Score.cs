using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public Text scoreText;
	public Text highScoreText;
	public Text scoreText2;
	public Text highScoreText2;
	public static bool highScoreStatic = false;
	public static bool score2Static = false;
	public static bool highScore2Static = false;
	private const string HighScoreKey = "HighScore";
	private static int playerScore = 0;
	private static int highScore = 0;

	// Update is called once per frame
	void Update()
	{
		// Update the score text
		scoreText.text = playerScore.ToString();
		// Update the high score text
		highScoreText.text = highScore.ToString();
		// Hide or show the high score text
		HideUnHideTexts();
	}
	
	public static void AddScore()
	{
		playerScore++;	
	}

	public static int GetScore()
	{
		return playerScore;
	}

	public static void ResetScore()
	{
		SaveHighScore();
		playerScore = 0;
	}
	
	public static void SaveHighScore()
	{
		if (playerScore > highScore)
		{
			PlayerPrefs.SetInt(HighScoreKey, playerScore);
			highScore = playerScore;
		}
	}

	public static void GetHighScore()
	{
		// Get the current highest score (or 0 if it doesn't exist)
		highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
	}
	// To use three text objects in another script because of the static variables can't be accessed in unity editor
	public static void HideUnHideTextsStatic()
	{
		highScoreStatic = !highScoreStatic;
		score2Static = !score2Static;
		highScore2Static = !highScore2Static;
	}
	public void HideUnHideTexts()
	{
		highScoreText.gameObject.SetActive(highScoreStatic);
		scoreText2.gameObject.SetActive(score2Static);
		highScoreText2.gameObject.SetActive(highScore2Static);
	}
}
