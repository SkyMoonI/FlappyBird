using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	[Header("-----------------Audio Sources-----------------")]
	[SerializeField] AudioSource musicSource;
	[SerializeField] AudioSource SFXSource;

	[Header("-----------------Audio Clips-----------------")]
	public AudioClip backgroud;
	public AudioClip death;
	public AudioClip jump;
	public AudioClip scoreUp;


	void Start()
	{
		musicSource.clip = backgroud;
		musicSource.volume = 0.05f;
		SFXSource.volume = 0.3f;
		musicSource.Play();
	}

	public void Play(AudioClip clip)
	{
		SFXSource.PlayOneShot(clip);
	}

}
