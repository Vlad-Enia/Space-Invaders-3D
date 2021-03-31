using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    /// <summary>
    /// Timer used for knowing when to spawn the enemies
    /// </summary>
    private float timer;

    /// <summary>
    /// Private reusable variable for getting the current respawn object
    /// </summary>
    private GameObject currentSpawnPoint;

    [Tooltip("Delay between respawn in seconds")]
    public float delayTime;

    /// <summary>
    /// Enemy prefab to be instanciated (Set in the Editor)
    /// </summary>
    public GameObject enemy;

    /// <summary>
    /// A list of current respawn points
    /// </summary>
    public List<GameObject> spawnPoints;

	// Use this for initialization
	void Start () {
        timer = Time.time + delayTime;
	}
	
	/// <summary>
    /// Spawn an Enemy at each delayTime interval
    /// </summary>
	void Update () {
		if(timer < Time.time)
        {
            currentSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count - 1)];

			Instantiate(enemy, currentSpawnPoint.transform);
            timer += delayTime;
        }
	}
}
