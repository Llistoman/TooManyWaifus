using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float HP;
    public float movSpeed = 10.0f;
    private Vector3 forward, right;
    
    // Use this for initialization
    void Start ()
    {
        GetVectors();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Update current forwards and right vectors
        GetVectors();

        //Move
        Vector3 forwardMovement = forward * movSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 rightMovement = right * movSpeed * Time.deltaTime * Input.GetAxis("Horizontal");

        Vector3 realForward = Vector3.Normalize(forwardMovement + rightMovement);

        //Diagonal movement was bigger, needs to be clamped
        Vector3 movement = Vector3.ClampMagnitude(forwardMovement + rightMovement, 0.06f);

        transform.forward += realForward;
        transform.position += movement;
    }

    void GetVectors()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0.0f;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        right = Vector3.Normalize(right);
    }

    public void GetHit(float damage)
    {
        HP -= damage;
        //Game over
        if (HP <= 0) Destroy(this.gameObject);
    }
}
