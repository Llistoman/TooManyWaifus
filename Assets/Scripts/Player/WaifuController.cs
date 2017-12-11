using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaifuController : MonoBehaviour {

    public GameObject[] WaifuSpawn;
    public GameObject[] WaifuPrefab;
    public GameObject[] Waifus;
    public float waifuRotSpeed;
    public int i;

	// Use this for initialization
	void Start () {
        i = 0;
        Waifus = new GameObject[3];
        //testing
        SpawnWaifu();
        SpawnWaifu();
        SpawnWaifu();
        //DeleteWaifu();
        //DeleteWaifu();
        //DeleteWaifu();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnWaifu()
    {
        GameObject lastWaifu;
        if (i == 0)
        {
            lastWaifu = Instantiate(WaifuPrefab[0], WaifuSpawn[0].transform.position, WaifuSpawn[0].transform.rotation);
            lastWaifu.GetComponent<WaifuRotation>().target = WaifuSpawn[0].transform;
            lastWaifu.GetComponent<WaifuRotation>().rotSpeed = waifuRotSpeed;
            Waifus[0] = lastWaifu;
            ++i;
        }
        else if (i == 1)
        {
            //symmetric positions
            lastWaifu = Instantiate(WaifuPrefab[1], WaifuSpawn[2].transform.position, WaifuSpawn[2].transform.rotation);
            lastWaifu.GetComponent<WaifuRotation>().target = WaifuSpawn[2].transform;
            lastWaifu.GetComponent<WaifuRotation>().rotSpeed = waifuRotSpeed;
            Waifus[1] = lastWaifu;
            Waifus[0].GetComponent<WaifuRotation>().target = WaifuSpawn[1].transform;
            ++i;
        }
        else if (i == 2)
        {
            lastWaifu = Instantiate(WaifuPrefab[2], WaifuSpawn[0].transform.position, WaifuSpawn[0].transform.rotation);
            lastWaifu.GetComponent<WaifuRotation>().target = WaifuSpawn[0].transform;
            lastWaifu.GetComponent<WaifuRotation>().rotSpeed = waifuRotSpeed;
            Waifus[2] = lastWaifu;
        }
    }

    void DeleteWaifu()
    {
        if (i == 0)
        {
            Waifus[0].GetComponent<WaifuDestroy>().DestroyWaifu();
            Waifus[0] = null;
        }
        else if (i == 1)
        {
            Waifus[1].GetComponent<WaifuDestroy>().DestroyWaifu();
            Waifus[0].GetComponent<WaifuRotation>().target = WaifuSpawn[0].transform;
            Waifus[1] = null;
            --i;
        }
        else if (i == 2)
        {
            Waifus[2].GetComponent<WaifuDestroy>().DestroyWaifu();
            Waifus[2] = null;
            --i;
        }
    }
}
