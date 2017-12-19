using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaifuController : MonoBehaviour {

    public GameObject level;
    public GameObject[] WaifuSpawn;
    public GameObject[] WaifuPrefab;
    public GameObject[] Waifus;
    public float waifuRotSpeed;
    public int nwaifus;

	// Use this for initialization
	void Start () {
        nwaifus = 0;
        Waifus = new GameObject[3];
        //testing
        //SpawnWaifu();
        //SpawnWaifu();
        //SpawnWaifu();
        //DeleteWaifu();
        //DeleteWaifu();
        //DeleteWaifu();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnWaifu()
    {
        if(nwaifus == 0)
        {
            Waifus[0] = Instantiate(WaifuPrefab[0], WaifuSpawn[0].transform.position, WaifuSpawn[0].transform.rotation);
            Waifus[0].transform.parent = this.gameObject.transform;
            Waifus[0].GetComponent<WaifuRotation>().target = WaifuSpawn[0].transform;
            Waifus[0].GetComponent<WaifuRotation>().rotSpeed = waifuRotSpeed;
            ++nwaifus;
        }
        else if(nwaifus == 1)
        {
            Waifus[1] = Waifus[0];
            Waifus[1].GetComponent<WaifuRotation>().target = WaifuSpawn[1].transform;
            Waifus[1].transform.rotation = WaifuSpawn[1].transform.rotation;
            Waifus[0] = null;
            Waifus[2] = Instantiate(WaifuPrefab[1], WaifuSpawn[2].transform.position, WaifuSpawn[2].transform.rotation);
            Waifus[2].transform.parent = this.gameObject.transform;
            Waifus[2].GetComponent<WaifuRotation>().target = WaifuSpawn[2].transform;
            Waifus[2].GetComponent<WaifuRotation>().rotSpeed = waifuRotSpeed;
            ++nwaifus;
        }
        else if(nwaifus == 2)
        {
            if(Waifus[0] == null)
            {
                Waifus[0] = Instantiate(WaifuPrefab[2], WaifuSpawn[0].transform.position, WaifuSpawn[0].transform.rotation);
                Waifus[0].transform.parent = this.gameObject.transform;
                Waifus[0].GetComponent<WaifuRotation>().target = WaifuSpawn[0].transform;
                Waifus[0].GetComponent<WaifuRotation>().rotSpeed = waifuRotSpeed;
                ++nwaifus;
            }
        }
    }

    public void DeleteWaifu()
    {
        if (nwaifus == 1)
        {
            if (Waifus[0] != null)
            {
                Waifus[0].GetComponent<WaifuDestroy>().DestroyWaifu();
                Waifus[0] = null;
                level.GetComponent<LevelController>().WaifuHitImage(1);
                --nwaifus;
            }
        }
        else if (nwaifus == 2)
        {
            Waifus[0] = Waifus[1];
            Waifus[0].GetComponent<WaifuRotation>().target = WaifuSpawn[0].transform;
            Waifus[1] = null;
            Waifus[2].GetComponent<WaifuDestroy>().DestroyWaifu();
            Waifus[2] = null;
            level.GetComponent<LevelController>().WaifuHitImage(2);
            --nwaifus;
        }
        else if (nwaifus == 3)
        {
            Waifus[0].GetComponent<WaifuDestroy>().DestroyWaifu();
            Waifus[0] = null;
            level.GetComponent<LevelController>().WaifuHitImage(3);
            --nwaifus;
        }
    }   
}
