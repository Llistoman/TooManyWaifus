using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaifuRotation : MonoBehaviour {

    public Transform target;
    public float rotSpeed;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        transform.position = target.position;
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BossBullet"))
        {
            this.gameObject.transform.parent.GetComponent<WaifuController>().DeleteWaifu();
        }
    }
}
