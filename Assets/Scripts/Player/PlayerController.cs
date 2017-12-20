using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject level;
    public float totalHP;
    public float HP;
    public float bossBulletDamage;
    public float movSpeed;
    public float rotSpeed;
    public Vector3 forward, right, movement;
    
    // Use this for initialization
    void Start ()
    {
        HP = totalHP;
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

        //Forward
        Vector3 forwardFace = forward * rotSpeed * Time.deltaTime * Input.GetAxis("LeftYaxis");
        Vector3 rightFace = right * rotSpeed * Time.deltaTime * Input.GetAxis("LeftXaxis");
        
        //Normalize for keyboard input
        Vector3 realForward = Vector3.Normalize(forwardFace + rightFace);

        //Clamp for uniform diagonals (xbox does not need this)
        movement = Vector3.ClampMagnitude(forwardMovement + rightMovement, 0.08f);

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
        if (HP <= 0)
        {
            level.GetComponent<LevelController>().GameOver();
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BossBullet"))
        {
            level.GetComponent<LevelController>().PlayerHit();
            GetHit(bossBulletDamage);
            this.gameObject.GetComponent<WaifuController>().DeleteWaifu();
            Destroy(other.gameObject);
        }
    }
}
