using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Acest script este responsabil pentru capacitatea jucatorului de a lansa proiectile;

public class PlayerShooter : MonoBehaviour {


	public float bulletSpeed;				//Variabila "bulletspeed" reprezinta viteza cu care proiectilul se va deplasa in scena; deoarece este de tip public, ea va putea fi modificata din editor;
	public GameObject bulletPrefab;			//Variabila "bulletPrefab" reprezinta entitatea caruia ii vom putea atribui obiectul 3d al proectilului, care va aparea in scena;
	public AudioClip bulletSound;			//Variabilei "bulletSound" ii vom atribui sunetul produs de jucator atunci cand lanseaza proiectilul;
	public Transform tip;					//Variabila "tip(=varful navei)" este de tip Transform, adica reprezinta locatia din care proiectilul va fi lansat;

	void Start () 
	{
	}


	void Update () 
	{
		if(Input.GetButtonDown ("Submit"))			//La apasarea butonului de pe tastatura cu tag-ul "submit", reprezentate de butoanele "enter" si "space"
		{
			AudioSource audio = GetComponent <AudioSource> ();
			audio.PlayOneShot (bulletSound);					//se produce sunetul;
			OnShoot();											//si se apeleaza functia OnShoot(); 
		}
	}
		
	public void OnShoot()
	{
		Debug.Log("I shoot");
		GameObject bullet = Instantiate(bulletPrefab, tip.position, tip.rotation, transform);		 	//se creeaza un nou proiectil in scena, avand pozitia (tip.position) si rotatia (tip.rotation) varfului navei (tip)
		bullet.transform.Rotate(Vector3.right, 90f);													//din cauza felului in care a fost construit modelul 3d al proiectiluli, el va trebui rotit la 90 grade;
		bullet.GetComponent<Rigidbody>().AddForce(tip.forward * bulletSpeed , ForceMode.Acceleration);  //proiectilul este lansat din fata varfului navei (tip.forward) cu viteza "bulletSpeed";
	}
}
