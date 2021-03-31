using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Aceast script este responsabil pentru functionalitatea meniului principal al jocului;

public class MainMenu : MonoBehaviour {

	public void PlayGame() 					// Aceasta functie asigura functionalitatea butonului de play;
	{
		SceneManager.LoadScene ("Game"); 	
	}

	public void QuitGame() 					// Aceasta functie asigura functionalitatea butonului quit;
	{
		Debug.Log ("QUIT");
		Application.Quit ();

	}
}
