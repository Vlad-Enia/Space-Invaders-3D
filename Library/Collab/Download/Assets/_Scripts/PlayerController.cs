using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Acest script este responsabil pentru miscarea jucatorului;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;				// Rigidbody reprezinta aspectul fizic al entitatii jucatorului, care poate fi miscat si care se supune legilor fizicii;
	public float speed;					// Variabila "speed" reprezinta viteza cu care putem misca jucatorul; Deoarece este de tip public, ea poate fi modificata din editor;
	void Start() 
	{
		rb = GetComponent<Rigidbody> ();		//Variabila "rb" este legata de aspectul rigidbody al jucatorului;
	}

	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");				//Jucatorul poate fi miscat doar in stanga si dreapta, adica doar pe axa orizontala a scenei;
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);		//Variabila "movement" este de tip vector3; acest tip modifica pozitia obiectului pe cele 3 axe, incepand cu axa orizontala; 
		rb.velocity = movement*speed;										//Asfel, pozitia jucatorului va fi modificata cu viteza "speed", declarata mai sus;
			
	}
}
