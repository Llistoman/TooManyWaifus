using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {

    public GameObject level;
    public GameObject target;
    public GameObject[] enemies;
    public float enemyRate;
    public float distSpawn;
    
    private bool allowSpawn;
    private bool spawning;

	// Use this for initialization
	void Start () {
        allowSpawn = true;
        spawning = false;
	}
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(target.transform.position, transform.position);
        if (dist >= distSpawn) allowSpawn = true;
        else allowSpawn = false;

        if(allowSpawn && !spawning)
        {
            allowSpawn = false;
            spawning = true;
            StartCoroutine(SpawnEnemy());
        }
    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
    }

    public void Enable()
    {
        this.gameObject.SetActive(true);
        allowSpawn = true;
        spawning = false;
    }

    //Spawns random enemies at a certain rate
    IEnumerator SpawnEnemy()
    {
        GameObject enemyPrefab = enemies[Random.Range(0, enemies.Length - 1)];
        GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
        enemy.GetComponent<EnemyController>().target = target;
        enemy.GetComponent<EnemyController>().level = level;

        float elapsedTime = 0;
        while (elapsedTime <= enemyRate)
        {
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        allowSpawn = true;
        spawning = false;
        level.GetComponent<LevelController>().EnemySpawned();
        yield return 0;
    }

    IEnumerator WaitForSec(float time)
    {
        float elapsedTime = 0;
        while (elapsedTime <= time)
        {
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        yield return 0;
    }
}
