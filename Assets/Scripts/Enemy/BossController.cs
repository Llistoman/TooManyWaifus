using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public GameObject level;
    public GameObject target;
    public GameObject bulletPrefab;
    public float totalHP;
    public float HP;
    public float attack;
    public float bulletDamage;
    public float rotSpeed;
    public float fireRate;
    public float bossBulletSpeed;
    private bool allowFire;

	// Use this for initialization
	void Start () {
        allowFire = true;
        HP = totalHP;
	}
	
	// Update is called once per frame
	void Update () {

        //Look at the player
        transform.LookAt(target.transform);
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(target.transform.position - transform.position), rotSpeed * Time.deltaTime);
        //rotate only on Y axis
        Vector3 angle = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(new Vector3(0,angle.y,0));

        //shooting pattern
        if (allowFire)
        {
            allowFire = false;
            StartCoroutine(FirePattern());
        }
    }

    //Spawns random enemies at a certain rate
    IEnumerator FirePattern()
    {
        GameObject bullet1 = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet1.transform.forward = transform.forward;
        bullet1.transform.position += bullet1.transform.forward * 2;
        bullet1.transform.position = new Vector3(bullet1.transform.position.x, 0.5f, bullet1.transform.position.z);
        bullet1.GetComponent<Rigidbody>().velocity = bullet1.transform.forward * bossBulletSpeed;

        GameObject bullet2 = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet2.transform.forward = transform.forward + transform.right;
        bullet2.transform.position += bullet2.transform.forward * 2;
        bullet2.transform.position = new Vector3(bullet2.transform.position.x, 0.5f, bullet2.transform.position.z);
        bullet2.GetComponent<Rigidbody>().velocity = bullet2.transform.forward * bossBulletSpeed;

        GameObject bullet3 = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet3.transform.forward = transform.forward - transform.right;
        bullet3.transform.position += bullet3.transform.forward * 2;
        bullet3.transform.position = new Vector3(bullet3.transform.position.x, 0.5f, bullet3.transform.position.z);
        bullet3.GetComponent<Rigidbody>().velocity = bullet3.transform.forward * bossBulletSpeed;

        float elapsedTime = 0;
        while (elapsedTime <= fireRate)
        {
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        allowFire = true;
        yield return 0;
    }

    //Collisions
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HP -= bulletDamage;
            Destroy(collision.gameObject);
            if (HP <= 0)
            {
                level.GetComponent<LevelController>().Win();
                this.gameObject.SetActive(false);
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().GetHit(attack);
        }
    }
}
