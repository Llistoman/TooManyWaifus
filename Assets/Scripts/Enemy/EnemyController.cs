using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject target;
    public float HP;
    public float attack;
    public float bulletDamage;
    //public float movSpeed;
    public float rotSpeed;
    private UnityEngine.AI.NavMeshAgent agent;

    // Use this for initialization
    void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //agent.speed = movSpeed;
        agent.angularSpeed = rotSpeed;
    }
	
	// Update is called once per frame
	void Update () {

        agent.SetDestination(target.transform.position);

        //Look at the player
        transform.LookAt(target.transform);
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(target.transform.position - transform.position), rotSpeed * Time.deltaTime);

        //Move towards the player
        //transform.position += (transform.forward * movSpeed * Time.deltaTime);*/
    }

    //Collisions
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HP -= bulletDamage;
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

