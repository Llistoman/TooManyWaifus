using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject target;
    public float HP;
    public float attack;
    public float movSpeed;
    public float rotSpeed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        //Look at the player
        transform.LookAt(target.transform);
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(target.transform.position - transform.position), rotSpeed * Time.deltaTime);

        //Move towards the player
        transform.position += (transform.forward * movSpeed * Time.deltaTime);
    }

    //Attack if collide
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HP -= 1.0f;
            Destroy(collision.gameObject);
            if (HP <= 0) Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().GetHit(attack);
            Destroy(this.gameObject);
        }
        
    }
}

