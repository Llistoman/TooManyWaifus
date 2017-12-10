using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaifuController : MonoBehaviour {

    public GameObject WaifuSpawn;
    public GameObject WaifuPrefab;
    public float waifuFollowDist;
    public float waifuMovSpeed;
    public float waifuRotSpeed;
    private GameObject lastWaifu;
    private GameObject player;

	// Use this for initialization
	void Start () {
        lastWaifu = null;
        player = GetComponentInParent<Transform>().gameObject;
        SpawnWaifu(player);
        SpawnWaifu(lastWaifu);
        SpawnWaifu(lastWaifu);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnWaifu(GameObject target)
    {
        lastWaifu = Instantiate(WaifuPrefab, WaifuSpawn.transform.position, WaifuSpawn.transform.rotation);
        WaifuSpawn = lastWaifu.transform.GetChild(0).gameObject;
        lastWaifu.GetComponent<WaifuFollowPlayer>().target = target;
        lastWaifu.GetComponent<WaifuFollowPlayer>().followDist = waifuFollowDist;
        lastWaifu.GetComponent<WaifuFollowPlayer>().movSpeed = waifuMovSpeed;
        lastWaifu.GetComponent<WaifuFollowPlayer>().rotSpeed = waifuRotSpeed;
    }
}
