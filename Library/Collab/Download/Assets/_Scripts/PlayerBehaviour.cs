using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Acest script controleaza comportamentul jucatorului;

public class PlayerBehaviour : MonoBehaviour {


    public int health;
	public GameObject healthValue; 		//Variabila "healthValue" contine viata jucatorului;
	public GameObject loserMenuUi; 		//Variabila "loserMenuUi" reprezinta obiectul care contine meniul de game over;
	public AudioClip explosionSound;	//Variabila "explosionSound" contine sunetul produs la impactul dintre proiectilul inamicului si jucatorul;

	void Start () {
		
	}

	void Update () {
		
	}
		
	
	public void OnCollisionEnter (Collision collision) //Aceasta functie este folosita pentru a ilustra efectul unei lovituri din partea inamicului;
	{
		Debug.Log("Hit!!");
		if (collision.gameObject.tag == "Enemy Bullet") //Astfel, la coliziunea cu proiectilul inamicului
		{ 
			AudioSource audio = GetComponent <AudioSource> ();
			audio.PlayOneShot (explosionSound);
			if (health > 25) { 								//daca avem mai mult de 25 viata ramasa,
				health -= 25; 							//viata va scadea cu 25
				healthValue.GetComponent<Text> ().text = health.ToString (); // iar valoarea curenta a vietii va fi afisata pe ecran;
			} else { 										//daca nu mai avem destula viata, atunci se va apela functia pause();
				health -= 25; 
				healthValue.GetComponent<Text> ().text = health.ToString ();
				Pause ();
			}
		}

	}

	void Pause() //Aceasta functie este responsabila pentru accesarea meniului de game over;
	{
		loserMenuUi.SetActive (true); //Astfel, pe ecran va aparea meniul de game over in sine;
		Time.timeScale = 0f; //Jocul va intra in repaus;
	} 


}