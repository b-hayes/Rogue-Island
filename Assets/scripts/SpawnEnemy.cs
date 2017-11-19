using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemy;
    public float timeBetweenSpawns = 1f;
	public int numberOfEnemies;
	int element;
    float timeUntilNextSpawn = 0f;

    new BoxCollider2D collider2D;


	void Start()
	{
        Data.EnemiesAlive = 0;
	}

	void Awake()
    {
        collider2D = GetComponent<BoxCollider2D>();
	}


	
	// Update is called once per frame
	void Update ()
    {
		
		if (timeUntilNextSpawn <= Time.timeSinceLevelLoad && numberOfEnemies != 0) {
			//Debug.Log (SpawnStart.spawnStart);
			timeUntilNextSpawn = Time.timeSinceLevelLoad + timeBetweenSpawns;

            Vector3 startingPosition = collider2D.bounds.center;//new Vector3 (collider2D.bounds.extents.x * Random.Range (-1f, 1f), collider2D.bounds.extents.y * Random.Range (-1f, 1f), 0);

			element = Random.Range (0, enemy.Length);
			GameObject enemyGO = GameObject.Instantiate (enemy[element]);
            enemyGO.transform.position = startingPosition;
            Data.EnemiesAlive++;
			numberOfEnemies--; 
        }
        
	}
		
}
