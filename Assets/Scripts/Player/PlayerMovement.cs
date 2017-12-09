﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float movSpeed = 10.0f;
    public Vector3 forward, right, movement;    
    
    // Use this for initialization
    void Start ()
    {
        GetVectors();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //update current forwards and right vectors
        GetVectors();

        //move
        Vector3 forwardMovement = forward * movSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 rightMovement = right * movSpeed * Time.deltaTime * Input.GetAxis("Horizontal");

        movement = Vector3.Normalize(forwardMovement + rightMovement);
        
        transform.forward += movement;
        transform.position += forwardMovement + rightMovement;
    }

    void GetVectors()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0.0f;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        right = Vector3.Normalize(right);
    }
}