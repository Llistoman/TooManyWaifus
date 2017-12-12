using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public int level;
    public int enemiesTotal;
    public int currentEnemies;
    public float enemyRate;
    public GameObject[] enemySpawns;


	// Use this for initialization
	void Start () {
        level = 1;
        enemiesTotal = 20;
        currentEnemies = 0;
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject spawn in enemySpawns)
        {
            currentEnemies += spawn.GetComponent<EnemySpawnController>().numSpawned;
        }

        if(currentEnemies >= enemiesTotal)
        {
            //TODO: add waifu to player if needed
            ++level;
            enemiesTotal += 10;
            enemyRate -= 0.1f;

            foreach (GameObject spawn in enemySpawns)
            {
                spawn.GetComponent<EnemySpawnController>().Reset();
            }
            
            //If last level spawn boss
            if(level == 5)
            {
                //
            }
        }
	}
}
