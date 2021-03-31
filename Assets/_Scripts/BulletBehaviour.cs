using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Acest script controleaza comportamentul proiectilului jucatorului;

public class BulletBehaviour : MonoBehaviour 
{

	public void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Enemy")			//La coliziunea cu inamicul, proiectilul va disparea;
		{
			Destroy (gameObject);
		}
	}

   
	private float timer=3f;

	void Start ()
	{
		Invoke ("Die", timer);								//Proiectilul este programat sa dispara la 3 secunde de la aparitia acestuia in scena;
	}
		
	
	void Die()
	{
		Destroy (gameObject);								//Astfel, in caz ca proiectilul nu a atins nimic, el va disparea din scena.
	}
}