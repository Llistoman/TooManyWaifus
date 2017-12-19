using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public int level;
    public int enemiesTotal;
    public int enemiesDestroyed;
    public int currentEnemiesSpawned;
    public float enemyRate;
    public float imageTime;
    public GameObject player;
    public GameObject bossPrefab;
    public GameObject bossSpawn;
    public GameObject bossHPBar;
    public GameObject levelBarText;
    public GameObject playerHitImage;
    public GameObject waifu1HitImage;
    public GameObject waifu2HitImage;
    public GameObject waifu3HitImage;
    public GameObject winImage;
    public GameObject gameOverImage;
    public GameObject pauseMenu;
    public GameObject[] enemySpawns;
    private bool end, disable;


	// Use this for initialization
	void Start () {
        level = 1;
        levelBarText.GetComponent<LevelBarController>().level = level;
        end = false;
        disable = false;
        foreach(GameObject spawn in enemySpawns)
        {
            spawn.GetComponent<EnemySpawnController>().enemyRate = enemyRate;
            spawn.GetComponent<EnemySpawnController>().Enable();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Joystick1Button7))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0.0f;
        }
        
        levelBarText.GetComponent<LevelBarController>().currentEnemies = currentEnemiesSpawned;
        levelBarText.GetComponent<LevelBarController>().destroyedEnemies = enemiesDestroyed;
        if (disable == false && currentEnemiesSpawned >= enemiesTotal)
        {
            disable = true;
            foreach (GameObject spawn in enemySpawns)
            {
                spawn.GetComponent<EnemySpawnController>().Disable();
            }
        }

        if(disable == true && enemiesDestroyed == currentEnemiesSpawned)
        {
            ++level;
            LevelUp();
            currentEnemiesSpawned = 0;
            enemiesDestroyed = 0;
            disable = false;
            if(level != 5)
            {
                enemiesTotal += 10;
                if(enemyRate - 0.2f > 0) enemyRate -= 0.2f;
                foreach (GameObject spawn in enemySpawns)
                {
                    spawn.GetComponent<EnemySpawnController>().enemyRate = enemyRate;
                    spawn.GetComponent<EnemySpawnController>().Enable();
                }
            }
            else
            {
                enemiesTotal += 1000;
                enemyRate = 3.0f;
                foreach (GameObject spawn in enemySpawns)
                {
                    spawn.GetComponent<EnemySpawnController>().enemyRate = enemyRate;
                    spawn.GetComponent<EnemySpawnController>().Enable();
                }
                GameObject boss = Instantiate(bossPrefab, bossSpawn.transform.position, bossSpawn.transform.rotation);
                boss.GetComponent<BossController>().target = player;
                boss.GetComponent<BossController>().level = this.gameObject;
                bossHPBar.GetComponent<HealthBarController>().target = boss;
                bossHPBar.transform.parent.gameObject.SetActive(true);
            }
        }
	}
    
    void LevelUp()
    {
        Debug.Log("level up");
        player.GetComponent<WaifuController>().SpawnWaifu();
        player.GetComponent<PlayerController>().HP += 2;
        if (player.GetComponent<PlayerController>().HP > player.GetComponent<PlayerController>().totalHP)
        player.GetComponent<PlayerController>().totalHP = player.GetComponent<PlayerController>().HP;
        
        levelBarText.GetComponent<LevelBarController>().level = level;
    }

    IEnumerator ImageDisplay(GameObject image)
    {
        image.SetActive(true);
        float elapsedTime = 0.0f;
        while (elapsedTime <= imageTime)
        {
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        image.SetActive(false);
        yield return 0;
    }

    public void PlayerHit()
    {
        StartCoroutine(ImageDisplay(playerHitImage));
    }

    public void WaifuHitImage(int i)
    {
        if (i == 1) StartCoroutine(ImageDisplay(waifu1HitImage));
        if (i == 2) StartCoroutine(ImageDisplay(waifu2HitImage));
        if (i == 3) StartCoroutine(ImageDisplay(waifu3HitImage));
    }

    public void EnemySpawned()
    {
        ++currentEnemiesSpawned;
    }

    public void EnemyDestroyed()
    {
        ++enemiesDestroyed;
    }

    public void Win()
    {
        Debug.Log("WIN");
        winImage.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
        gameOverImage.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
