using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeamlessAudio : MonoBehaviour 
{
	public AudioSource music;

	void Awake()
	{
		music = GetComponent<AudioSource> ();
		if (Time.timeScale == 1) 
		{
			DontDestroyOnLoad (transform.gameObject);
		} 
		else
			music.Stop ();
		

			
			

	}
}
