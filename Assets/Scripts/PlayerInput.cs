using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public float movSpeed = 10.0f;
    public Vector3 forward, right;

    public CharacterController characterController;

    // Use this for initialization
    void Start () {
        forward = Camera.main.transform.forward;
        forward.y = 0.0f;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0,90,0)) * forward;
        //right.y = 0.0f;
        right = Vector3.Normalize(right);

        characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 heading = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 forwardMovement = forward * movSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 rightMovement = right * movSpeed * Time.deltaTime * Input.GetAxis("Horizontal");

        Vector3 movement = Vector3.Normalize(forwardMovement + rightMovement);
        transform.forward = movement;
        transform.position += forwardMovement + rightMovement;
	}
}
