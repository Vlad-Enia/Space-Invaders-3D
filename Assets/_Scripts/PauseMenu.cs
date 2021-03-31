using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Acest script este responsabil pentru functionalitatea unui meniu de pauza;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false; //Aceasta variabila va fi folosita (atat in cadrul acestui script, cat si in alte script-uri) pentru a putea verifica daca jocul este in pauza sa nu;
	public GameObject pauseMenuUi; //Acestui obiect ii vom atribui meniul de pauza in sine;

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) //Pentru intrarea, dar si iesirea din meniul de pauza, folosim tasta Escape;
		{
			if (GameIsPaused) //Daca deja ne aflam in meniul de pauza, atunci la apasarea tastei escape, vom iesi din meniu;
			{
				Resume();
			} 
			else //Daca nu, vom intra in meniul de pauza;
			{
				Pause();
			}
		}
	}

	public void Resume() //Aceasta functie este responsabila pentru parasirea meniului de pauza;
	{
		pauseMenuUi.SetActive (false); //Astfel, obiectul meniului de pauza in sine va disparea de pe ecran;
		Time.timeScale = 1f; //Jocul va iesi din repaus;
		GameIsPaused = false; 
	}

	void Pause() //Aceasta functie este responsabila pentru accesarea meniului de pauza;
	{
		pauseMenuUi.SetActive (true); //Astfel, pe ecran va aparea meniul de pauza in sine;
		Time.timeScale = 0f; //Jocul va intra in repaus;
		GameIsPaused = true;
	}

	public void LoadMenu() //Aceasta functie asigura functionalitatea butolului de accesare a meniului principal;
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene ("Menu");
		Debug.Log ("Loading Main Menu");
	}

	public void QuitGame() //Aceasta funtie asigura functionalitatea butonului de iesire din joc;
	{
		Debug.Log ("QUIT");
		Application.Quit ();
	}

	public void Restart() //Aceasta funtie asigura functionalitatea butonului de restart;
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene ("Game");
	}
}


