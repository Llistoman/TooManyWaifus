using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaifuFollowPlayer : MonoBehaviour {

    public GameObject target;
    public float followDist;
    public float movSpeed;
    public float rotSpeed;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        transform.LookAt(target.transform);
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(target.transform.position - transform.position), rotSpeed * Time.deltaTime);
        float dist = Vector3.Distance(target.transform.position, transform.position);

        if (dist >= followDist)
        {
            transform.position += (transform.forward * movSpeed * Time.deltaTime);
        }    
    }
}
