using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBarController : MonoBehaviour {
    public int level;
    public int currentEnemies;
    public int destroyedEnemies;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        int enemies = currentEnemies - destroyedEnemies;
        if (enemies < 0) enemies = 0;
        if (level != 5)
            GetComponent<Text>().text = ("Lvl: " + level.ToString() + " / Enemies: " + enemies.ToString());
        else
            GetComponent<Text>().text = ("Lvl: " + level.ToString() + " / Kill Boss!");
    }
}
