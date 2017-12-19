using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelleteBullets : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("BossBullet"))
        {
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BossBullet"))
        {
            Destroy(other.gameObject);
        }
    }
}
