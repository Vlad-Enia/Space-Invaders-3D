using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Acest script controleaza comportamentul proiectilului inamicului;

public class EnemyBulletBehavior : MonoBehaviour {

	public void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Player")			//La coliziunea cu jucatorul, proiectilul inamicului va disparea.
		{
			Destroy (gameObject);
		}
	}
				
	public float timer;										//Variabila "timer" va reprezenta un interval de secunde; Deoarece acesta este de tip public, el poate fi modificat din editor;

	void Start ()
	{
		Invoke ("Die", timer);								//Proiectilul este programat sa dispara la un acel interval de secunde de la aparitia acestuia in scena;
	}


	void Die()
	{
		Destroy (gameObject);								//Astfel, in caz ca proiectilul nu a atins nimic, el va disparea din scena.
	}
}
