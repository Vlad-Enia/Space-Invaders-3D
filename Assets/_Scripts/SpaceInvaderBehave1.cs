using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Acest script este responsabil pentru comportamentul inamicului;

public class SpaceInvaderBehave1 : MonoBehaviour 
{

	public AudioSource diesound;			//Variabilei "diesound" ii vom atribui sunetul produs atunci cand inamicul este distrus;
	public GameObject bulletPrefab1;		//Variabila "bulletPrefab" reprezinta entitatea caruia ii vom putea atribui obiectul 3d al proectilului, care va aparea in scena;
	public Transform enemyGun;				//Variabila "enemyGun" este de tip Transform, adica reprezinta locatia din care proiectilul va fi lansat;
	public int rate;						//Rate reprezinta frecventa cu care inamicul lanseaza proiectilele; deoarece este de tip publi, ea va putea fi modificata din editor;
	public float bulletSpeed;				//Variabila "bulletspeed" reprezinta viteza cu care proiectilul se va deplasa in scena; deoarece este de tip public, ea va putea fi modificata din editor;
	private int ok=1;						//Cu variabila "ok" vom verifica daca inamicul este distrus sau nu;

	void Start () 
	{
		diesound = GetComponent<AudioSource> ();
	}

	void Update()
	{
		if (ok == 1) {
			StartCoroutine (EnemyShooter ());		//Daca inamicul nu este mort, atunci el va lansa proiectile cu frecventa "rate"; acest lucru este realizat cu ajutorul functiei EnemyShooter();
		}
	}

	public IEnumerator EnemyShooter()			//Aceasta functie este identica cu cea din PlayerShooter, singura diferenta fiind ca ea nu este apelata la apasarea unui buton, ci cu frecventa "rate" si cat timp inamicul traieste;
	{
		ok = 0;
		yield return new WaitForSeconds(rate);
		Debug.Log ("Enemy shot");
		GameObject bullet = Instantiate (bulletPrefab1, enemyGun.position, enemyGun.rotation, transform);
		bullet.transform.Rotate(Vector3.right, 90f);
		bullet.GetComponent<Rigidbody> ().AddForce (enemyGun.forward * bulletSpeed, ForceMode.Acceleration);
		ok = 1;
	}


	public void OnCollisionEnter (Collision collision)	//Aceasta functie este responsabila pentru distrugerea inamicului;
	{
		if (collision.gameObject.tag == "Bullet")		//astfel, daca inamicul intra in coliziune cu proectilul jucatorului, care are tag-ul "Bullet"
		{
			diesound.Play ();							//se va produce un sunet
			StartCoroutine(KillEnemy());				//se va apela functia KillEnemy, care distruge inamicul; acest apel nu este unul simplu, ci prin metoda StartCoroutine,
														//care ne asigura de faptul ca mai intai se va produce sunetul, si apoi va fi distrus inamicul; 
														//daca am fi folosit un apel simpu, inamicul ar fi fost ditrus insa fara producerea sunetului;

		}
	}

	public IEnumerator KillEnemy()
	{
		yield return new WaitForSeconds(0.2f);			//WaitForSeconds reprezinta intervalul de tip intre producerea sunetului si distrugerea inamicului;
		Destroy(gameObject);
	}
}
