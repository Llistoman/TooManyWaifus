using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaifuDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DestroyWaifu()
    {
        //Do stuff before destroying
        Destroy(this.gameObject);
    }
}
